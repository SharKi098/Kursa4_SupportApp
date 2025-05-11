using Пр4.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Пр4
{
    public partial class ManageTicketsPage : Page
    {
        private SupportAppDbContext _context;

        public ManageTicketsPage()
        {
            try
            {
                InitializeComponent();
                _context = new SupportAppDbContext();
                LoadTickets();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadTickets()
        {
            try
            {
                TicketsListView.ItemsSource = _context.Tickets
                    .Include("Category")
                    .Include("Creator")
                    .Select(t => new
                    {
                        id = t.TicketId,
                        Title = t.Title,
                        Status = t.Status,
                        Priority = t.Priority,
                        CreatedDate = t.CreatedAt
                    }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var statusItem = FilterStatusComboBox.SelectedItem as ComboBoxItem;
                if (statusItem == null) return;

                var status = statusItem.Content.ToString();
                var query = _context.Tickets.AsQueryable();

                if (status == "Открытые")
                    query = query.Where(t => t.Status == "Open");
                else if (status == "В работе")
                    query = query.Where(t => t.Status == "in_progress");
                else if (status == "Закрытые")
                    query = query.Where(t => t.Status == "Closed");

                TicketsListView.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка фильтрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TicketsListView.SelectedItem == null)
                {
                    MessageBox.Show("Выберите тикет для изменения статуса", "Предупреждение",
                                   MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var selectedId = (TicketsListView.SelectedItem as dynamic)?.Id;
                if (selectedId == null) return;

                var ticket = _context.Tickets.Find(selectedId);
                if (ticket == null)
                {
                    MessageBox.Show("Тикет не найден", "Ошибка",
                                  MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                ticket.Status = GetNextStatus(ticket.Status);
                _context.SaveChanges();
                LoadTickets();
            }
            catch (DbUpdateException dbEx)
            {
                MessageBox.Show($"Ошибка сохранения: {dbEx.InnerException?.Message}", "Ошибка БД",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Общая ошибка: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetNextStatus(string currentStatus)
        {
            switch (currentStatus?.Trim().ToLower())
            {
                case "open":
                    return "InProgress";
                case "InProgress":
                    return "Closed";
                default:
                    return "open";
            }
        }
    }
}
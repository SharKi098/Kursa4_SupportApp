using Пр4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Пр4
{
  
        public partial class ManageEmployeesPage : Page
        {
            private SupportAppDbContext _context;
            private UsersModel _selectedUser;

            public ManageEmployeesPage()
            {
                InitializeComponent();
                _context = new SupportAppDbContext();
                LoadData();
            }
        // Загрузка данных
        private void LoadData()
        {
            LoadRoles();
            LoadEmployees();
        }

        // Загрузка ролей в ComboBox
        private void LoadRoles()
        {
            cmbRoles.ItemsSource = _context.Roles.ToList();
        }

        // Загрузка сотрудников в ListView
        private void LoadEmployees()
        {
            EmployeesListView.ItemsSource = _context.Users
                .Include("Role")
                .Select(u => new
                {
                    user_id = u.UserId,
                    email = u.Email,
                    department = u.Department,
                    Rolename = u.Role.RoleName,
                    created_at = u.CreatedAt
                })
                .ToList();
        }


        // Сохранение сотрудника
        private void SaveEmployee_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    if (_selectedUser == null)
                    {
                        // Создание нового пользователя
                        var newUser = new UsersModel
                        {
                            Email = txtEmail.Text,
                            PasswordHash = HashHelper.HashPassword(txtPassword.Password),
                            RoleId = (int)cmbRoles.SelectedValue,
                            CreatedAt = DateTime.Now
                        };
                        _context.Users.Add(newUser);
                    }
                    else
                    {
                        // Обновление существующего пользователя
                        _selectedUser.Email = txtEmail.Text;
                        _selectedUser.RoleId = (int)cmbRoles.SelectedValue;
                        if (!string.IsNullOrEmpty(txtPassword.Password))
                        {
                            _selectedUser.PasswordHash = HashHelper.HashPassword(txtPassword.Password);
                        }
                    }

                    _context.SaveChanges();
                   
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }

        // Выбор сотрудника для редактирования
        private void EmployeesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeesListView.SelectedItem is UsersModel selected)
            {
                _selectedUser = _context.Users.Find(selected.UserId);
                txtEmail.Text = _selectedUser.Email;
                cmbRoles.SelectedValue = _selectedUser.RoleId;
                txtPassword.Clear();
            }
        }


        // Удаление сотрудника
        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
            {
                var button = sender as Button;
                int userId = (int)button.Tag;

                var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    LoadEmployees();
                }
            }

            // Создание нового сотрудника
            private void NewEmployee_Click(object sender, RoutedEventArgs e)
            {
                _selectedUser = null;
                ClearFields();
            }

            // Очистка полей
            private void ClearFields()
            {
                txtEmail.Clear();
                txtPassword.Clear();
                cmbRoles.SelectedIndex = -1;
            }
        }
    
}
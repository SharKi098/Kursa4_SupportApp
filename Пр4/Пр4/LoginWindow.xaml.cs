using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Пр4

{

    public partial class LoginWindow : Window
    {
        private int loginAtt = 0;
        private const int MaxAtt = 3;
        private const int LockoutTimeInSeconds = 30;
        private DispatcherTimer lockoutTimer;
        public LoginWindow()

        {

            InitializeComponent();
            InitializeLockoutTimer();

        }
        private void InitializeLockoutTimer()
        {
            lockoutTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(LockoutTimeInSeconds) };
            lockoutTimer.Tick += UnlockLogin;
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)

        {
        
                if (lockoutTimer.IsEnabled)
                {
                    ShowError($"Попробуйте снова через {LockoutTimeInSeconds} секунд.");
                    return;
                }

                string username = LoginBox.Text;

                string password = PasswordBox.Password;





                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))

                {

                    ShowError("Логин и пароль не могут быть пустыми.");

                    return;

                }
                string Check = CheckPass(username, password);

            if (Check != "false")
            {
                if (Check == "admin")
                {
                    MessageBox.Show("Вы вошли как админ.");
                    AdminPanel adminpanel = new AdminPanel();
                    adminpanel.Show();
                    Close();
                }

                else if (Check == "work")
                {
                    MessageBox.Show("Вы вошли как сотрудник.");
                    EmployeePanel em = new EmployeePanel();
                    em.Show();
                    Close();
                }
            }
            else
            {
                loginAtt++;
                if (loginAtt >= MaxAtt)
                {
                    ShowError($"Аккаунт заблокирован на {LockoutTimeInSeconds} секунд.");
                    if (lockoutTimer.IsEnabled) { lockoutTimer.Start(); }
                }
                else
                {
                    ShowError($"Неверные логин или пароль. Осталось попыток: {MaxAtt - loginAtt}");
                }
            }

                 

                
        

        }
        

        private string CheckPass(string username, string password)
        {
            string filePath = "C:\\Users\\konst\\Desktop\\Visual\\Пр4\\Пр4\\log.txt";
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && parts[0] == username && parts[1] == password)
                {
                    return parts[0].Trim().ToLower();
                }
            }
            return "false";

        }

        private void ShowError(string message)

        {

            ErrorMessageTextBlock.Text = message;

        }
        private void UnlockLogin(object sender, EventArgs e) 
        { lockoutTimer.Stop(); loginAtt = 0; ShowError("Вы можете попытаться войти снова."); }
    }
}





    
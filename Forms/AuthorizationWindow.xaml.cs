using Demo.Data;
using Demo.Objects;
using System;
using System.Collections.Generic;
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

namespace Demo.Forms
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }
        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginTextBox.Text) && !string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                Database.OpenConnection();
                Database.SetQuery($"SELECT * FROM Пользователи WHERE логин=@login AND пароль=@password");
                Database.AddParameter("@login", LoginTextBox.Text);
                Database.AddParameter("@password", PasswordTextBox.Text);
                var reader = Database.ExecuteReader();
                if (reader.Read())
                {
                    User.SetUser(reader["ФИО"].ToString(), Convert.ToInt32(reader["id_роли_сотрудника"]));
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Такого пользователя нет!");
                    reader.Close();
                    Database.ClearParameters();
                    Database.CloseConnection();
                    return;
                }
                reader.Close();
                Database.ClearParameters();
                Database.CloseConnection();
            }
            else
            {
                MessageBox.Show($"Введите логин и пароль!");
            }
        }



        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            User.SetUser("", 0);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

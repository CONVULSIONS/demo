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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LabelUserName.Content = User.Name;
            LoadProducts();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            User.CleareUser();
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }
        private void LoadProducts()
        {
            var products = new List<Product>();
            Database.OpenConnection();
            Database.SetQuery("SELECT COUNT(*) FROM Товары");
            int count = Convert.ToInt32(Database.ExecuteScalar());
            for (int tempId = 0; tempId <= count; tempId++)
            {
                Database.SetQuery("SELECT * FROM Товары WHERE id_товара=@tempId");
                Database.AddParameter("@tempId", tempId);
                var reader = Database.ExecuteReader();
                if (reader.Read())
                {
                    products.Add(new Product(Convert.ToInt32(reader["id_товара"]), reader["артикул"].ToString(), reader["наименование"].ToString(), Convert.ToInt32(reader["цена"]), reader["единица_измерения"].ToString(), Convert.ToInt32(reader["скидка"]), Convert.ToInt32(reader["количество_на_складе"]), Convert.ToInt32(reader["id_поставщика"]), Convert.ToInt32(reader["id_производителя"]), Convert.ToInt32(reader["id_категории"]), reader["описание"].ToString(), reader["фото"].ToString()));
                } 
                Database.ClearParameters();
            }

            ItemsControlProductsList.ItemsSource = products;
        }

    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void LoginBtnClick(object sender, RoutedEventArgs e)
        {
            Пользователи users = new Пользователи();

            using(TestEntities usersdb = new TestEntities())
            {
                users = usersdb.Пользователи.Where(p => p.Логин == LoginBox.Text && p.Пароль == PassBox.Text).FirstOrDefault();
            }
            if(RandCapha.Text == "")
            {
                MessageBox.Show("Подтвердите капчу!");
            }
            else
            {
                if (users != null)
                {
                    if (Answer.Text == RandCapha.Text)
                    {
                        MessageBox.Show("Авторизация выполена успешно!");
                        Manager.MainFrame.Navigate(new MenuPage());
                    }
                    else
                    {
                        MessageBox.Show("Капча введена не верно!");
                    }
                }
            }
            
        }

        private void RegBtnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegPage(null));
        }

        private void RandBtnClick(object sender, RoutedEventArgs e)
        {
            RandCapha.Text = null;

            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZqwertyuiopasdfghjklzxcvbnm0123456789".ToCharArray();

            Random randomCapha = new Random();

            string randCaphaWord = "";

            for (int j = 1; j <= 6; j++)
            {
                int letterNum = randomCapha.Next(0, letters.Length -1);

                // Добавить письмо.
                randCaphaWord += letters[letterNum];
            }

            RandCapha.Text = randCaphaWord;
        }
    }
}

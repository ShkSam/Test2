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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        private Пользователи _newUser = new Пользователи();
        public RegPage(Пользователи selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null)
                _newUser = selectedUser;

            DataContext = _newUser;
        }

        private void RegBtnClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_newUser.Логин))
                errors.AppendLine("Введите логин!");
            if (string.IsNullOrWhiteSpace(_newUser.Пароль))
                errors.AppendLine("Введите пароль!");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_newUser.Код_Работника == 0)
            {
                TestEntities.GetContext().Пользователи.Add(_newUser);
            }

            try
            {
                TestEntities.GetContext().SaveChanges();
                MessageBox.Show("+reg");
                Manager.MainFrame.Navigate(new AuthPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AuthPage());
        }
    }
}

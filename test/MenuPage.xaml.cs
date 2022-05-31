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
using System.Windows.Threading;

namespace test
{
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();

            TestList.ItemsSource = TestEntities.GetContext().ТоварыНаСкладе.ToList();

            FiltrComboBox.ItemsSource = TestEntities.GetContext().ВидыПродуктов.ToList();
            
            Updatelist();

            TimerMin.Text = "00";
            TimerSec.Text = "00";

            SortComboBox.SelectedIndex = 0;
        }

        public void Updatelist()
        {
            var search = TestEntities.GetContext().ТоварыНаСкладе.ToList();
            search = search.Where(p => p.Название_Товара.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
            if (SortComboBox.SelectedIndex == 1)
                search = search.OrderBy(p => p.Цена).ToList();
            if (SortComboBox.SelectedIndex == 2)
                search = search.OrderByDescending(p => p.Цена).ToList();
            if(FiltrComboBox.SelectedIndex >= 0)
                search = search.Where(p => p.ВидыПродуктов == FiltrComboBox.SelectedItem).ToList();

            TestList.ItemsSource = search;
        }

        private void SearchChanged(object sender, TextChangedEventArgs e)
        {
            Updatelist();
        }

        private void SortBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            Updatelist();
        }

        private void SortChanged(object sender, SelectionChangedEventArgs e)
        {
            Updatelist();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dts = new DispatcherTimer();

            dts.Interval = TimeSpan.FromSeconds(1);
            dts.Tick += dtTikers;
            dts.Start();

        }
        private int secTick = 0;
        private int m = 0;

        private void dtTikers(object sender, EventArgs e)
        {
            secTick++;
            if (secTick<=9)
            {
                TimerSec.Text = "0"+ secTick.ToString();
            }
            else
            {
                TimerSec.Text = secTick.ToString();
                if(secTick >58)
                {
                    secTick = 0;
                    m++;
                }
            }

            if (m <= 9)
            {
                TimerMin.Text = "0" + m;
            }
            else
            {
                TimerSec.Text = secTick.ToString();
                if (m > 58)
                {
                    m = 0;
                }
            }
        }

        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show($"Вы точно хотите выйти?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Manager.MainFrame.Navigate(new AuthPage());
            }
        }
    }
}

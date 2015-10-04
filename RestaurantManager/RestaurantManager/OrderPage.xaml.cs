using RestaurantManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RestaurantManager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderPage : Page
    {
        public OrderPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = MenuItemsList.SelectedValue;
            if (selected != null)
            {
                DataManager dm = Application.Current.Resources["DataManager"] as DataManager;
                dm.CurrentlySelectedMenuItems.Add(selected as string);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataManager dm = Application.Current.Resources["DataManager"] as DataManager;

            StringBuilder sb = new StringBuilder();
            foreach (string i in dm.CurrentlySelectedMenuItems)
            {
                if (sb.Length != 0)
                {
                    sb.Append(", ");
                }
                sb.Append(i);
            }

            dm.OrderItems.Add(sb.ToString());
            dm.CurrentlySelectedMenuItems.Clear();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}

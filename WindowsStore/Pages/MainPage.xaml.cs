using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Entities;

namespace WindowsStore
{
    public sealed partial class MainPage : Page
    {
        public User User { get { return this.DataContext as User; } }
        private List<Product> ProductsList;
        public MainPage()
        {
            this.InitializeComponent();
            ProductsList = new List<Product>();
        }

        private void CartButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (AddProductPane.Height == 0)
                OpenPane.Begin();
            else
                ClosePane.Begin();
        }

        private void ProductsGrid_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}

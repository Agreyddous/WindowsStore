using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using WindowsStore.Entities;
using WindowsStore.Handlers;
using WindowsStore.UserControls;

namespace WindowsStore
{
    public sealed partial class MainPage : Page
    {
        public User User;
        public ObservableCollection<Product> ProductsList;
        public MainPage()
        {
            this.InitializeComponent();
            ProductsList = new ObservableCollection<Product>();
        }

        private void CartButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(User.Admin)
            {
                NewProduct.Visibility = Visibility.Visible;
                NewProduct.IsEnabled = true;
            }

            else
            {
                //See Cart
            }
        }

        private async void LogInControl_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            User = (User)(sender as LogInControl).DataContext;

            if (User != null)
            {
                LogIn.IsEnabled = false;
                LogIn.Visibility = Visibility.Collapsed;
                UpdateLayout();
                UserImageSource.ImageSource = new BitmapImage(new Uri(User.ImageSource));
                UserImage.IsTapEnabled = true;
                ActionButton.IsTapEnabled = true;

                if(User.Admin)
                    ActionButtonImageSource.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Add.png"));
                else
                    ActionButtonImageSource.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Cart.png"));

                if (await FilesHandler.CheckIfExistsFile("list.li"))
                {
                    ObservableCollection<Product> List = new ObservableCollection<Product>();
                    List = await FilesHandler.RetrieveListContent("list.li");
                    ProductsList.Clear();

                    foreach (Product product in List)
                    {
                        ProductsList.Add(product);
                    }
                }
            }
        }

        private void UserImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            UserImage.IsTapEnabled = false;
            ActionButton.IsTapEnabled = false;
            LogIn.IsEnabled = true;
            LogIn.Visibility = Visibility.Visible;
        }

        private async void NewProduct_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            if ((Product)(sender as NewProduct).DataContext != null)
            {
                Product newProduct = (Product)(sender as NewProduct).DataContext;
                ProductsList.Add(newProduct);
                await FilesHandler.StoreList(ProductsList);
            }

            NewProduct.IsEnabled = false;
            NewProduct.Visibility = Visibility.Collapsed;
            UpdateLayout();
            }
        }
}
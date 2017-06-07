using System;
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Controls;
using WindowsStore.Entities;
using WindowsStore.Handlers;

namespace WindowsStore.UserControls
{
    public sealed partial class NewProduct : UserControl
    {
        private Product Product;
        public NewProduct() => InitializeComponent();

        private async void CompleteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Regex regex = new Regex(@"^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$");

            if (ProductDescriptionBox.Text.Trim() != "" && ProductNameBox.Text.Trim() != "" && ProductPriceBox.Text.Trim() != "" && ProductImageUrl.Text.Trim() != "" && regex.IsMatch(ProductPriceBox.Text))
            {
                ErrorOutput.Text = "";
                try
                {
                    Product = new Product(ProductNameBox.Text, ProductDescriptionBox.Text, float.Parse(ProductPriceBox.Text), 10, 0, ProductImageUrl.Text);

                    if (!(await FilesHandler.CheckIfExistsFile(Product.Name + ".prod")))
                    {
                        await FilesHandler.StoreProduct(Product);
                    }

                    Clean();
                    DataContext = Product;
                }
                catch (Exception)
                {
                    ErrorOutput.Text = "Input incorreto";
                }
            }

            else
                ErrorOutput.Text = "Input incorreto";
        }

        private void ExitButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Clean();
            DataContext = null;
        }

        private void Clean()
        {
            ProductDescriptionBox.Text = "";
            ProductImageUrl.Text = "";
            ProductNameBox.Text = "";
            ProductPriceBox.Text = "";
        }
    }
}

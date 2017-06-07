using Windows.UI.Xaml.Controls;
using WindowsStore.Entities;

namespace WindowsStore.UserControls
{
    public sealed partial class ProductsControl : UserControl
    {
        public Product Product { get { return this.DataContext as Product; } }
        public ProductsControl()
        {
            this.InitializeComponent();
            DataContextChanged += (s, e) => UpdateLayout();

            ProductPrice.Text = "$" + Product.Price;
        }
    }
}

using System;
using Windows.UI.Xaml.Media.Imaging;

namespace WindowsStore.Entities
{
    public class Product : Entity
    {
        public Product(String name, String description, float price, int quantityAvailable, int quantity, BitmapSource image)
        {
            Name = name;
            Description = description;
            Price = price;
            QuantityAvailable = quantityAvailable;
            Quantity = quantity;
            Image = image;
        }

        public String Name { get; private set; }
        public String Description { get; private set; }
        public float Price { get; private set; }
        public int QuantityAvailable { get; private set; }
        public int Quantity { get; private set; }
        public BitmapSource Image { get; private set; }
    }
}
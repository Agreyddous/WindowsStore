using System;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Media.Imaging;

namespace WindowsStore.Entities
{
    [DataContract]
    public class Product : Entity
    {
        public Product(String name, String description, float price, int quantityAvailable, int quantity, string image)
        {
            Name = name;
            Description = description;
            Price = price;
            QuantityAvailable = quantityAvailable;
            Quantity = quantity;
            Image = image;
        }

        [DataMember]
        public String Name { get; private set; }
        [DataMember]
        public String Description { get; private set; }
        [DataMember]
        public float Price { get; private set; }
        [DataMember]
        public int QuantityAvailable { get; private set; }
        [DataMember]
        public int Quantity { get; private set; }
        [DataMember]
        public string Image { get; private set; }
    }
}
using System.Collections.Generic;
using WindowsStore.Enums;

namespace WindowsStore.Entities
{
    public class Cart
    {
        public Cart(List<Product> list, float discount)
        {
            List = list;
            Discount = discount / 100;
        }

        public List<Product> List { get; private set; }
        public float LiquidPrice { get; private set; }
        public float Discount { get; private set; }

        public void AddItem(Product product)
        {
            List.Add(product);
        }

        public void AddDiscount(float discount) => Discount += discount / 100;
    }
}
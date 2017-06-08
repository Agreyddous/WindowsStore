using System.Collections.Generic;
using System.Runtime.Serialization;
using WindowsStore.Enums;

namespace WindowsStore.Entities
{
    [DataContract]
    public class Cart
    {
        public Cart(List<Product> list, float discount)
        {
            List = list;
            Discount = discount / 100;
        }

        [DataMember]
        public List<Product> List { get; private set; }
        [DataMember]
        public float LiquidPrice { get; private set; }
        [DataMember]
        public float Discount { get; private set; }

        public void AddItem(Product product)
        {
            List.Add(product);
        }

        public void AddDiscount(float discount) => Discount += discount / 100;
    }
}
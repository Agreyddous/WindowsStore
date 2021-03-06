﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Enums;

namespace WindowsStore.Entities
{
    [DataContract]
    public class Purchase : Entity
    {
        public Purchase(User user, Cart cart, PaymentChoice paymentChoice)
        {
            User = user;

            if (paymentChoice == PaymentChoice.Money || paymentChoice == PaymentChoice.Debit_Card)
                cart.AddDiscount(10);

            Cart = cart;

            foreach (Product product in cart.List)
                SubTotal += (product.Price * product.Quantity);

            Total = SubTotal * cart.Discount;
            Date = DateTime.Now;
        }

        [DataMember]
        public User User { get; private set; }
        [DataMember]
        public Cart Cart { get; private set; }
        [DataMember]
        public float Total { get; private set; }
        [DataMember]
        public float SubTotal { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
    }
}
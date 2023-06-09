﻿namespace Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsFulfilled { get; set; }

        #region NavigationProperty
        public ICollection<OrderDetails> OrderDetails { get; set; }

        #endregion

    }
}

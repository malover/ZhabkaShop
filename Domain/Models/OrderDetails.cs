﻿namespace Domain.Models
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }


        #region NavigationProperty
        public Product? Product { get; set; }
        public Order Order { get; set; }

        #endregion

    }
}

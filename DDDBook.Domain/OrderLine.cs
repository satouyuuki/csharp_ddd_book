using System;
namespace DDDBook.Domain
{
	public class OrderLine
	{
		public decimal Price = 0;
		private Product _product;

		public OrderLine(Product product)
		{
			_product = product;
			Price = product.UnitPrice;
		}

		public Product Product
        {
            get { return _product; }
        }

		public int NumberOfUnits { get; set; }

		public decimal TotalAmount
        {
            get { return Price * NumberOfUnits; }
        }
	}
}


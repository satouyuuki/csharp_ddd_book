using System;
namespace DDDBook.Domain
{
	public class Product
	{
		private string _description;
		private decimal _unitPrice;

		public Product(string description, double unitPrice)
		{
			_description = description;
			_unitPrice = (decimal)unitPrice;
		}

		public string Description
        {
            get { return _description; }
        }
		public decimal UnitPrice
        {
            get { return _unitPrice; }
        }
	}
}


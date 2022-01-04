using System;
namespace DDDBook.Domain
{
	public static class OrderFactory
	{
		public static Order CreateOrder(Customer customer)
        {
			return new Order(customer);
        }
	}
}


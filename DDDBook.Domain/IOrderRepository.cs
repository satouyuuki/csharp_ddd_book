using System;
using System.Collections;

namespace DDDBook.Domain
{
	public interface IOrderRepository
	{
		IList GetOrders(Customer customer);
		Order GetOrder(int orderNumber);
		void AddOrder(Order order);
	}
}


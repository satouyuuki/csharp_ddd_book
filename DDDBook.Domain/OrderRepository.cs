using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace DDDBook.Domain
{
	public class OrderRepositoryFake: IOrderRepository
	{
		private IList<Order> _theOrders = new List<Order>();

		public IList GetOrders(Customer customer)
        {
			IList theResult = new ArrayList();

			foreach(Order o in _theOrders)
            {
				//if (o.Customer.Equals(customer))
				if(o.Customer.CustomerNumber == customer.CustomerNumber)
					theResult.Add(o);
            }
			return theResult;
        }

		public Order GetOrder(int orderNumber)
        {
			//return new Order(new Customer());
			foreach(Order o in _theOrders)
            {
				if (o.OrderNumber == orderNumber)
					return o;
            }
			return null;
		}
		public void AddOrder(Order order)
        {
			int theNumberOfOrdersBefore = _theOrders.Count;

			_theOrders.Add(order);
            // TODO
            //Trace.Assert(theNumberOfOrdersBefore == _theOrders.Count);
			//MyTrace.Assert(theNumberOfOrdersBefore == _theOrders.Count + 1);
		}
    }
}


using System;
using System.Collections;

namespace DDDBook.Domain
{
	public enum OrderType
    {
		hoge,
		fuga
    }
	public class Order
	{
		public OrderType OrderType;
		private DateTime _orderDate;
		private int _orderNumber;
		public readonly CustomerSnapshot Customer;

		private IList _orderLines = new ArrayList();
		public IList OrderLines
        {
            get { return ArrayList.ReadOnly(_orderLines); }
        }
		public void AddOrderLine(OrderLine orderLine) {
			_orderLines.Add(orderLine);
		}

		public Order(Customer customer)
		{
			Customer = customer.TakeSnapshot();
            //Customer = customer;
            _orderDate = DateTime.Now;
		}

		public DateTime OrderDate
        {
            get { return _orderDate; }
        }
		// 読み出し専用
		public int OrderNumber
        {
			get { return _orderNumber; }
        }

        public decimal TotalAmount
		{
            get
            {
				decimal theSum = 0;
				foreach (OrderLine ol in _orderLines)
				{
					theSum += ol.TotalAmount;
				}
				return theSum;
			}
		}
    }
}


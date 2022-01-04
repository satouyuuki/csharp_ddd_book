using System;
using System.Collections;

namespace DDDBook.Domain
{
	public class Order
	{
		private DateTime _orderDate;
		private int _orderNumber;
		public readonly Customer Customer;
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
			Customer = customer;
			_orderDate = DateTime.Now;
		}

		//没案
		//public Order(int orderNumber, DateTime orderDate, Customer customer)
		//      {
		//      }
		//public void SetFieldWhenReconstitutingFromPersistence
		//	(int fieldKey, object value)
		//{ }


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
            //get { return 0; }
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


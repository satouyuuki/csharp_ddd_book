using System;
namespace DDDBook.Domain
{
	public class Customer
	{
		private int _customerNumber;
		public int CustomerNumber
        {
			get { return _customerNumber; }
        }
		public string Name { get; set; }

		public Customer()
		{
		}

        public CustomerSnapshot TakeSnapshot()
        {
			return new CustomerSnapshot(Name, CustomerNumber);
        }
    }
}


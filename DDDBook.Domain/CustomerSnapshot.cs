using System;
namespace DDDBook.Domain
{
	public class CustomerSnapshot
	{
		private int _customerNumber;
		public int CustomerNumber
		{
			get { return _customerNumber; }
		}
		public string Name { get; set; }
		public CustomerSnapshot(string name, int customerNumber)
		{
			Name = name;
			_customerNumber = customerNumber;
		}
	}
}


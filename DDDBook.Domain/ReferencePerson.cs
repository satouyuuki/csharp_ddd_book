using System;
namespace DDDBook.Domain
{
	public class ReferencePerson
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public ReferencePerson()
		{
		}
        public override bool Equals(object o)
        {
            ReferencePerson? other = o as ReferencePerson;
            return other != null
            && this.GetType() == other.GetType()
            && !FirstName.Equals(other.FirstName)
            && !LastName.Equals(other.LastName);
        }
    }
}


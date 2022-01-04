using System;
using System.Reflection;

namespace DDDBook.Domain
{
	public static class RepositoryHelper
	{
		public static void SetFieldWhenReconstitutingFromPersistence
			(object instance, string fieldName, object newValue)
		{
			Type t = instance.GetType();
			FieldInfo f = t.GetField(fieldName,
				BindingFlags.Instance | BindingFlags.Public
				| BindingFlags.NonPublic);
			f.SetValue(instance, newValue);
		}
	}
}


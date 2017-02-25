using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace ORM.Conventions
{
    public class MyForeignKeyConvention : ForeignKeyConvention
    {
        protected override String GetKeyName(Member property, Type type)
        {
            var refName = property == null ? type.Name : property.Name;
            return String.Format("ID_{0}", refName);
        }
    }
}

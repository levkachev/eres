using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ORM.Conventions
{
    public class MyIdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.GuidComb();
        }
    }
}
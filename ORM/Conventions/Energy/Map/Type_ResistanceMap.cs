using FluentNHibernate.Mapping;
using ORM.Energy.Entities;

namespace ORM.Energy.Map
{
    /// <summary>
    /// Справочник кабелей
    /// </summary>
    public class Type_ResistanceMap: ClassMap<Type_Resistance>
    {
        public Type_ResistanceMap()
        {
            Id(x => x.ID);
            Map(x => x.Resistance).Not.Nullable();
            Map(x => x.Type).Length(45).Not.Nullable();
        }
    }
}

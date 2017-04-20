using FluentNHibernate.Mapping;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Map
{
    /// <summary>
    /// Профиль перегона
    /// </summary>
    public class Profil_StageMap : ClassMap<Profil_Stage>
    {
        /// <summary>
        /// 
        /// </summary>
        public Profil_StageMap()
        {
            Table("Line.Profil_Stage");
            Id(x => x.ID);
            Map(x => x.Slope).Not.Nullable();
            Map(x => x.End_Slope).Not.Nullable();
            References(x => x.Stage).ForeignKey("ID_Stage");
           
        }
    }
}

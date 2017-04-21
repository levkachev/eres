using FluentNHibernate.Mapping;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Map
{
    /// <summary>
    /// Профиль перегона
    /// </summary>
    public class ProfileStageMap : ClassMap<ProfileStage>
    {
        /// <summary>
        /// 
        /// </summary>
        public ProfileStageMap()
        {
            Table("Stage.ProfileStage");
            Id(x => x.ID);
            Map(x => x.Slope).Not.Nullable();
            Map(x => x.End_Slope).Not.Nullable();
            References(x => x.Stage).ForeignKey("ID_Stage");
           
        }
    }
}

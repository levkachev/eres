using FluentNHibernate.Mapping;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Map
{
    /// <summary>
    /// ARS Перегон
    /// </summary>
    public class ASRStageMap : ClassMap<ASRStage>
    {
        /// <summary>
        /// 
        /// </summary>
        public ASRStageMap()
        {
            Table("Stage.ASRStage");
            Id(x => x.ID);
            Map(x => x.Velocity).Not.Nullable();
            Map(x => x.EndVelocity).Not.Nullable();
            References(x => x.Stage).ForeignKey("ID_Stage");

        }
    }
}
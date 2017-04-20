using FluentNHibernate.Mapping;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Map
{
    /// <summary>
    /// ARS Перегон
    /// </summary>
    public class ASR_StageMap : ClassMap<ASR_Stage>
    {
        /// <summary>
        /// 
        /// </summary>
        public ASR_StageMap()
        {
            Table("Line.ASR_Stage");
            Id(x => x.ID);
            Map(x => x.Velocity).Not.Nullable();
            Map(x => x.End_Velocity).Not.Nullable();
            References(x => x.Stage).ForeignKey("ID_Stage");

        }
    }
}
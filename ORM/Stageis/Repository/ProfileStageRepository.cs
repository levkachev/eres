using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Base;
using ORM.Stageis.Entities;

namespace ORM.Stageis.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class ProfileStageRepository : Repository<ProfileStage>
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">factory is <see langword="null"/></exception>
        public static ProfileStageRepository GetInstance()
        {
            return GetInstance<ProfileStageRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stage"></param>
        /// <returns></returns>
        public IEnumerable<ProfileStage> GetLimits(Guid stage)
        {

            return GetAll()
                .Where(st => st.Stage.ID == stage)
                .Select(st => new ProfileStage());
        }
    }
}

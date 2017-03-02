using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace ORM.Base
{
    public interface IRepository<T>
    {
        /// <summary>
        /// get all instance in the entity
        /// </summary>
        /// <returns></returns>
        IList<T> GetAll();
        /// <summary>
        /// get instance by <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(Guid id);
        /// <summary>
        /// save the <paramref name="entity"/>
        /// </summary>
        /// <param name="entity"></param>
       
    }
}

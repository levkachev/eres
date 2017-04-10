using System;
using System.Collections.Generic;

namespace ORM.Base
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
       
    }
}

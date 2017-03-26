using ORM.Base;
using NHibernate;
using ORM.Train.Entities;
using System.Linq;
using System.Collections.Generic;
using System;


namespace ORM.Train.Repositories
{
    public class АdditionalParameterRepository : Repository<АdditionalParameter>
    {
        internal static АdditionalParameterRepository GetInstance()
        {
            return GetInstance<АdditionalParameterRepository>(SessionWrapper.GetInstance().Factory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static АdditionalParameter GetАdditionalParameter()
        {
            var repository = АdditionalParameterRepository.GetInstance();
            return repository.GetAll().FirstOrDefault();
        }
    }
}

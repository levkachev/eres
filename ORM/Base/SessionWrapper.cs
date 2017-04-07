using NHibernate;

namespace ORM.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class SessionWrapper
    {
        /// <summary>
        /// 
        /// </summary>
        public ISessionFactory Factory { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        protected SessionWrapper(ISessionFactory factory)
        {
            Factory = factory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public static SessionWrapper GetInstance()
        {
            return new SessionWrapper(SessionFactory.GetSessionFactory());
        }
    }
}

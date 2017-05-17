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
        protected static SessionWrapper Wrapper;

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public static SessionWrapper GetInstance()
        {
            if (Wrapper == null)
                Wrapper = new SessionWrapper(SessionFactory.GetSessionFactory());
            return Wrapper;
        }
    }
}

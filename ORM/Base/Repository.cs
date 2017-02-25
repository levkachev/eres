using System;
using System.Collections.Generic;
using NHibernate;

namespace ORM.Base
{
    public class Repository<T> : IRepository<T> where T : Entity<T>
    {
       
        private static volatile Repository<T> repository;

        private static readonly Object SynchronizationRoot = new Object();

        /// <summary>
        /// The static method returns the single <see cref="repository"/> in all threads
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <param name="factory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/> is <see langword="null"/></exception>
        protected static TRepository GetInstance<TRepository>(ISessionFactory factory)
        where TRepository : Repository<T>, new()
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            if (repository == null)
                lock (SynchronizationRoot)
                    if (repository == null)
                        repository = new TRepository { sessionFactory = factory };
            return repository as TRepository;
        }
        /// <summary>
        /// store session factory
        /// </summary>
        private ISessionFactory sessionFactory;

        private ISession session;

        /// <summary>
        /// open session in the session factory
        /// </summary>
        protected virtual ISession Session
        {
            get
            {
                if (session == null)
                    session = sessionFactory.OpenSession();
                return session;
            }
        }

        /// <summary>
        /// ctr by default for children
        /// </summary>
        protected Repository()
        {
        }

        /// <summary>
        /// ctr to fill session factory
        /// </summary>
        /// <param name="factory"></param>
        /// <exception cref="ArgumentNullException">Condition.</exception>
        protected Repository(ISessionFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            sessionFactory = factory;
        }
        /// <summary>
        /// realization CRUD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(Int32 id)
        {
            return Transact(() => Session.Get<T>(id));
        }
   
        /// <summary>
        /// realization CRUD
        /// </summary>
        /// <returns></returns>
        public IList<T> GetAll()
        {
            return Transact(() => Session.CreateCriteria<T>().List<T>());
        }

        public ICriteria GetCriteria()
        {
            return Transact(() => Session.CreateCriteria<T>());
        }

        /// <summary>
        /// wrapping transaction in one method
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="func"/> is <see langword="null"/></exception>
        protected virtual TResult Transact<TResult>(Func<TResult> func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));

            if (Session.Transaction.IsActive)
                return func.Invoke();

            // Wrap in transaction
            TResult result;
            using (var tx = Session.BeginTransaction())
            {
                result = func.Invoke();
                tx.Commit();
            }
            return result;
            // Don't wrap;
        }
        /// <summary>
        /// wrapping transaction in one method
        /// </summary>
        /// <param name="action"></param>
        protected virtual void Transact(Action action)
        {
            Transact<Boolean>(() =>
            {
                action.Invoke();
                return false;
            });
        }
    }
}

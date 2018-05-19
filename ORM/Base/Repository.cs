using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using ORM.Energies.Entities;

namespace ORM.Base
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T> : IRepository<T> where T : Entity<T>
    {
        /// <summary>
        /// 
        /// </summary>
        private static volatile Repository<T> repository;

        /// <summary>
        /// 
        /// </summary>
        private static readonly Object synchronizationRoot = new Object();

        /// <summary>
        /// The static method returns the single <see cref="repository"/> in all threads
        /// </summary>
        /// <typeparam name="TRepository"></typeparam>
        /// <param name="factory"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/> is <see langword="null"/></exception>
        protected static TRepository GetInstance<TRepository>(ISessionFactory factory) where TRepository : Repository<T>, new()
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (repository is null)
                lock (synchronizationRoot)
                    if (repository is null)
                        repository = new TRepository { sessionFactory = factory };
            var tmp = (TRepository) repository;// as TRepository;
            return tmp;
        }
        /// <summary>
        /// store session factory
        /// </summary>
        private ISessionFactory sessionFactory;

        /// <summary>
        /// 
        /// </summary>
        private ISession session;

        /// <summary>
        /// Open session in the session factory
        /// </summary>
        protected virtual ISession Session => session ?? (session = sessionFactory.OpenSession());

        /// <summary>
        /// ctr by default for children
        /// </summary>
        protected Repository() { }

        /// <summary>
        /// ctr to fill session factory
        /// </summary>
        /// <param name="factory"></param>
        /// <exception cref="ArgumentNullException">Condition.</exception>
        protected Repository(ISessionFactory factory) => sessionFactory = factory ?? throw new ArgumentNullException(nameof(factory));

        /// <summary>
        /// realization CRUD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(Guid id) => Transact(() => Session.Get<T>(id));

        /// <summary>
        /// Метод, извлекающий из хранилища объект по его наименованию.
        /// </summary>
        /// <param name="name">Уникальное наименование объекта.</param>
        /// <returns></returns>
        public abstract T GetByName(String name);

        /// <summary>
        /// Метод, извлекающий из хранилища код (<see cref="Guid"/>) объекта по его (объекта) наименованию.
        /// </summary>
        /// <param name="name">Уникальное наименование объекта.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="predicate" /> — <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Condition.</exception>
        public virtual Guid GetIdByName(String name) => GetByName(name)?.ID ?? throw new ArgumentOutOfRangeException(nameof(name));

        /// <summary>
        /// realization CRUD
        /// </summary>
        /// <returns></returns>
        public IList<T> GetAll() => Transact(() => Session.CreateCriteria<T>().List<T>());

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ICriteria GetCriteria() => Transact(() => Session.CreateCriteria<T>());

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

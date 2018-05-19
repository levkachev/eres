using System;
using System.Collections.Generic;

namespace ORM.Base
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Entity<T>  where T : Entity<T>
    {
        public virtual Guid ID { get; protected set; }

        public override Boolean Equals(Object obj) => Equals(obj as Entity<T>);

        public virtual Boolean Equals(Entity<T> other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (IsTransient(this) || IsTransient(other) || !Equals(ID, other.ID))
                return false;

            var otherType = other.GetUnproxiedType();
            var thisType = GetUnproxiedType();
            return thisType.IsAssignableFrom(otherType) || otherType.IsAssignableFrom(thisType);
        }

        private static Boolean IsStaticNew(Entity<T> obj) => obj != null && obj.ID == Guid.Empty;

        private static Boolean IsTransient (Entity<T> obj) => obj != null && Equals(obj.ID, default(T));

        private Type GetUnproxiedType() => GetType();

        private Guid? oldHashCode;

        private Boolean IsNew() => ID == Guid.Empty;

        public override Int32 GetHashCode()
        {
            if (Equals (ID, default(T)))
                return base.GetHashCode();
            return ID.GetHashCode();          
        }

        public static Boolean operator ==(Entity<T> lhs, Entity<T> rhs) => Equals(lhs, rhs);

        public static Boolean operator !=(Entity<T> lhs, Entity<T> rhs) => !Equals(lhs, rhs);

        protected static String MakeReport<TElement>(IEnumerable<TElement> collection, String message) =>
            $"{message}: {String.Join("; ", collection)}{Environment.NewLine}";
    }

    public class NamedEntity<T> : Entity<T> where T : NamedEntity<T>
    {
        /// <summary>
        /// Уникальное (человекочитаемое) наименование сущности.
        /// </summary>
        public virtual String Name { get; protected set; }
    }
}

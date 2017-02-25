using System;

namespace ORM.Base
{

    public abstract class Entity<T> where T : Entity<T>
    {
        public virtual Guid ID { get; protected set; }

        public override Boolean Equals(Object obj)
        {
            return Equals(obj as Entity<T>);
        }
        public virtual Boolean Equals(Entity<T> other)
        {
           
            if (other == null)
                return false;


            if (ReferenceEquals (this, other))
                return true;

           if (!IsTransient (this) &&
                !IsTransient (other) &&
                Equals(ID, other.ID))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                    otherType.IsAssignableFrom(thisType);
            }
            return false;
        }

        private static Boolean IsTransient (Entity<T> obj)
        {
            return obj != null &&
                 Equals(obj.ID, default(T));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        private Guid? oldHashCode;

        private Boolean IsNew()
        {
            return ID == new Guid();
        }

        public override Int32 GetHashCode()
        {
            
            if (Equals (ID, default(T)))
                return base.GetHashCode();
            return ID.GetHashCode();
                    
        }

        public static Boolean operator ==(Entity<T> lhs, Entity<T> rhs)
        {
            return Equals(lhs, rhs);
        }

        public static Boolean operator !=(Entity<T> lhs, Entity<T> rhs)
        {
            return !Equals(lhs, rhs);
        }
    }
}

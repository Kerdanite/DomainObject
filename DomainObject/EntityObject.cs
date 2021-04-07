using System;

namespace DomainObject
{
    public class EntityObject<TId> : IEquatable<EntityObject<TId>>
    {
        private readonly TId _id;

        protected EntityObject(TId id)
        {
            if (object.Equals(id, default(TId)))
            {
                throw new ArgumentException("Id is default value");
            }

            _id = id;
        }

        public TId Id => _id;

        public override bool Equals(object obj)
        {
            if (obj is EntityObject<TId> entity)
            {
                return this.Equals(entity);
            }

            return false;
        }

        public bool Equals(EntityObject<TId> other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ias.Domain
{
    // Подробнее здесь:
    // https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects

    /// <summary>
    /// Базовый класс для объектов значений.
    /// </summary>
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
        }


        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }

            return ReferenceEquals(left, null) || left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }


        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var obj in this.GetAtomicValues())
            {
                hash = hash * 31 + (obj == null ? 0 : obj.GetHashCode());
            }

            return hash;
        }
    }
}

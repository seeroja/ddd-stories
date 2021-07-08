using System.Collections.Generic;
using Ias.Domain;

namespace Ias.Tests.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public int Number { get; private set; }
        public int ZipCode { get; private set; }

        protected Address()
        {
        }

        public Address(string street, int number, int zipCode)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return Number;
            yield return ZipCode;
        }
    }


    public class Address2 : ValueObject
    {
        public string Street { get; private set; }
        public int Number { get; private set; }
        public int ZipCode { get; private set; }

        protected Address2()
        {
        }

        public Address2(string street, int number, int zipCode)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            // yield return Street; -Ignored
            yield return Number;
            yield return ZipCode;
        }
    }
}

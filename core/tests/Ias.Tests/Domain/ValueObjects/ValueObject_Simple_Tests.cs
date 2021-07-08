using Xunit;

namespace Ias.Tests.Domain.ValueObjects
{
    public class ValueObject_Simple_Tests
    {
        [Fact]
        public void ValueObjects_IfContainsSameData_ShouldBeSame()
        {
            var address1 = new Address("Washington Street", 125, 000001);
            var address2 = new Address("Washington Street", 125, 000001);

            Assert.True(address1.Equals(address2));
            Assert.True(address2.Equals(address1));

            Assert.True(address1 == address2);
            Assert.True(address2 == address1);

            Assert.Equal(address1.GetHashCode(), address2.GetHashCode());
        }

        [Fact]
        public void ValueObjects_IfContainsDifferentData_ShouldNotBeSame()
        {
            var address1 = new Address("Washington Street", 125, 000001);
            var address2 = new Address("West Street", 21, 000001);

            Assert.False(address1.Equals(address2));
            Assert.False(address2.Equals(address1));

            Assert.True(address1 != address2);
            Assert.True(address2 != address1);

            Assert.NotEqual(address1.GetHashCode(), address2.GetHashCode());
        }

        [Fact]
        public void ValueObjects_IfOneOfThemIsNull_ShouldNotBeEquals()
        {
            Assert.False(new Address("West Street", 21, 000001).Equals(null));
        }

        [Fact]
        public void ValueObjects_IfOneContainsNullableProperty_ShouldNotBeSame()
        {
            var address1 = new Address("Washington Street", 125, 000001);
            var address2 = new Address(null, 125, 000001);

            Assert.False(address1.Equals(address2));
            Assert.False(address2.Equals(address1));

            Assert.True(address1 != address2);
            Assert.True(address2 != address1);
        }

        [Fact]
        public void ValueObjects_IfIgnoredPropertyDiff_ShouldBeSame()
        {
            var address1 = new Address2(null, 42, 000001);  // Street is ignored
            var address2 = new Address2("Baris Manco Street", 42, 000001);

            Assert.True(address1.Equals(address2));
            Assert.True(address2.Equals(address1));

            Assert.True(address1 == address2);
            Assert.True(address2 == address1);
        }

        [Fact]
        public void ValueObjects_IfNotIgnoredPropertyDiff_ShouldNotBeSame()
        {
            var address1 = new Address(null, 42, 000001);
            var address2 = new Address("Baris Manco Street", 42, 000001);

            Assert.False(address1.Equals(address2));
            Assert.False(address2.Equals(address1));

            Assert.True(address1 != address2);
            Assert.True(address2 != address1);
        }
    }
}

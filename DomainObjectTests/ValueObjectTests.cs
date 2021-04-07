using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DomainObject.Tests
{
    [TestClass()]
    public class ValueObjectTests
    {
        [TestMethod()]
        public void EqualsTest_DifferentValues_ShouldFail()
        {
            Money five = new Money(5);
            Money six = new Money(6);

            Assert.AreNotEqual(five, six);
        }

        [TestMethod()]
        public void EqualsTest_SameValues_ShouldSucceed()
        {
            Money five = new Money(5);
            Money otherFive = new Money(5);

            Assert.AreEqual(five, otherFive);
        }
    }

    public class Money : ValueObject<Money>
    {
        public decimal Amount { get; private set; }

        public Money(decimal amount)
        {
            Amount = amount;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Amount;
        }
    }
}
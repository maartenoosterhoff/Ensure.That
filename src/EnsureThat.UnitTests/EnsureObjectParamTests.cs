using FluentAssertions;
using System;
using Xunit;

namespace EnsureThat.UnitTests
{
    public class EnsureObjectParamTests : UnitTestBase
    {
        [Fact]
        public void IsNotNull_WhenRefTypeIsNull_ThrowsArgumentNullException()
        {
            object value = null;

            AssertAll<ArgumentNullException>(
                ExceptionMessages.EnsureExtensions_IsNotNull,
                () => Ensure.That(value, ParamName).IsNotNull(),
                () => EnsureArg.IsNotNull(value, ParamName));
        }

        [Fact]
        public void IsNotNull_WhenRefTypeIsNotNull_ReturnsPassedObjectInstance()
        {
            var item = new { Value = 42 };

            var returnedItem = Ensure.That(item, ParamName).IsNotNull();
            AssertReturnedAsExpected(returnedItem, item);

            Action a = () => EnsureArg.IsNotNull(item, ParamName);
            a.ShouldNotThrow();
        }
    }
}
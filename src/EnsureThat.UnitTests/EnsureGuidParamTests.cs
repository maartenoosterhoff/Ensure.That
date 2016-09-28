using System;
using FluentAssertions;
using Xunit;

namespace EnsureThat.UnitTests
{
    public class EnsureGuidParamTests : UnitTestBase
    {
        [Fact]
        public void IsNotEmpty_WhenEmptyGuid_ThrowsArgumentException()
        {
            AssertAll<ArgumentException>(
                ExceptionMessages.EnsureExtensions_IsEmptyGuid,
                () => Ensure.That(Guid.Empty, ParamName).IsNotEmpty(),
                () => EnsureArg.IsNotEmpty(Guid.Empty, ParamName));
        }

        [Fact]
        public void IsNotEmpty_WhenNonEmptyGuid_ReturnsPassedGuid()
        {
            var guid = Guid.NewGuid();

            var returnedValue = Ensure.That(guid, ParamName).IsNotEmpty();
            AssertReturnedAsExpected(returnedValue, guid);

            Action a = () => EnsureArg.IsNotEmpty(guid, ParamName);
            a.ShouldNotThrow();
        }
    }
}
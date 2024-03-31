using Bogus;
using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Tests.Common.Helpers;
using Devpack.Extensions.Types;
using FluentAssertions;
using Xunit;

namespace Devpack.Extensions.Tests.Types
{
    public class EnumExtensionsTests : UnitTestBase
    {
        [Fact]
        public void GetDescription_WhenEnumMemberDescription()
        {
            var description = "Valor 1";
            var result = EnumTest.Valor1.GetDescription();

            result.Should().Be(description);
        }

        [Fact]
        public void GetDescription_WhenEnumMemberName()
        {
            var description = nameof(EnumTest.Valor2);
            var result = EnumTest.Valor2.GetDescription();
            
            result.Should().Be(description);
        }

        [Fact]
        public void GetDisplayName_WhenHasDisplayName()
        {
            var expectedDisplayName = "Valor 3";
            var result = EnumTest.Valor3.GetDisplayName();

            result.Should().Be(expectedDisplayName);
        }

        [Fact]
        public void GetDisplayName_WhenNoHasDisplayName()
        {
            var displayName = nameof(EnumTest.Valor2);
            var result = EnumTest.Valor2.GetDescription();

            result.Should().Be(displayName);
        }

        [Fact]
        public void ToNumberString()
        {
            var faker = new Faker();

            var enumumerator = faker.Random.Enum<EnumTest>();
            var expectedString = ((int)enumumerator).ToString();

            enumumerator.ToNumberString().Should().Be(expectedString);
        }
    }
}
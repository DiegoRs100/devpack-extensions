using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Types;
using FluentAssertions;
using Xunit;

namespace Devpack.Extensions.Tests.Types
{
    public class IntExtensionsTests : UnitTestBase
    {
        [Fact(DisplayName = "Deve retotnar verdadeiro quando um inteiro estiver dentro de um range específico.")]
        [Trait("Category", "Extensions")]
        public void IsBetween_BeTrue()
        {
            //Arrange
            var number = _faker.Random.Number(10, 100);
            var lastNumber = number + 1;
            var firstNumber = number - 1;

            //Act
            var result = number.IsBetween(firstNumber, lastNumber);

            //Assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retotnar falso quando um inteiro estiver fora de um range específico.")]
        [Trait("Category", "Extensions")]
        public void Between_BeFalse()
        {
            //Arrange
            var number = _faker.Random.Number(10, 100);
            var lastNumber = number + 2;
            var firstNumber = number + 1;

            //Act
            var result = number.IsBetween(firstNumber, lastNumber);

            //Assert
            result.Should().BeFalse();
        }
    }
}
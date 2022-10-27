using Devpack.Extensions.Helpers;
using Devpack.Extensions.Tests.Common;
using FluentAssertions;
using Xunit;

namespace SiteMercado.Foundation.Extensions.Tests.Helpers
{
    public class StringHelperTests : UnitTestBase
    {
        [Fact(DisplayName = "Deve retornar verdadeiro quando ao menos um dos valores for diferente de nulo e vazio.")]
        [Trait("Category", "Helpers")]
        public void HasValueInAny_BeTrue()
        {
            //Arrange
            var word = _faker.Random.Word();

            //Act
            var result = StringHelper.HasValueInAny(null!, word, string.Empty);

            //Assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar falso quando todos os valores forem nulos ou vazios.")]
        [Trait("Category", "Helpers")]
        public void HasValueInAny_BeFalse()
        {
            //Arrange
            var values = string.Empty;
            
            //Act
            var result = StringHelper.HasValueInAny(null!, values);

            //Assert
            result.Should().BeFalse();
        }
    }
}
using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Tests.Common.Helpers;
using Devpack.Extensions.Types;
using FluentAssertions;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using Xunit;

namespace Devpack.Extensions.Tests.Extensions
{
    public class ReflectionExtensionsTests : UnitTestBase
    {
        [Fact(DisplayName = "Deve retornar o atributo de uma propriedade quando ele existir na mesma.")]
        [Trait("Categoria", "Extensions")]
        public void GetAttribute()
        {
            //Arrange
            var description = "Valor 1";
            var type = typeof(EnumTest);
            var memberInfo = type.GetMember(EnumTest.Valor1.ToString()).First();

            //Act
            var result = memberInfo.GetAttribute<DescriptionAttribute>();

            //Assert
            result?.Description.Should().Be(description);
        }

        [Fact(DisplayName = "Deve retornar verdadeiro quando um atributo existir em uma propriedade.")]
        [Trait("Categoria", "Extensions")]
        public void HasAttribute_BeTrue()
        {
            //Arrange
            var type = typeof(EnumTest);
            var memberInfo = type.GetMember(EnumTest.Valor1.ToString()).First();

            //Act
            var result = memberInfo.HasAttribute<DescriptionAttribute>();

            //Asset
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar falso quando um atributo não existir em uma propriedade.")]
        [Trait("Categoria", "Extensions")]
        public void HasAttribute_BeFalse()
        {
            //Arrange
            var type = typeof(EnumTest);
            var memberInfo = type.GetMember(EnumTest.Valor1.ToString()).First();

            //Act
            var result = memberInfo.HasAttribute<JsonAttribute>();

            //Assert
            result.Should().BeFalse();
        }
    }
}
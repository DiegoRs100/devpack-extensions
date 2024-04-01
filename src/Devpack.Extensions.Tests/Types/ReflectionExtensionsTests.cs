using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Tests.Common.Helpers;
using Devpack.Extensions.Types;
using FluentAssertions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using Xunit;

namespace Devpack.Extensions.Tests.Types
{
    public class ReflectionExtensionsTests : UnitTestBase
    {
        [Fact(DisplayName = "Deve retornar o atributo de uma propriedade quando ele existir na mesma.")]
        [Trait("Category", "Extensions")]
        public void GetAttribute()
        {
            //Arrange
            var description = "Valor 1";
            var type = typeof(EnumTest);
            var memberInfo = type.GetMember(EnumTest.Valor1.ToString())[0];

            //Act
            var result = memberInfo.GetAttribute<DescriptionAttribute>();

            //Assert
            result?.Description.Should().Be(description);
        }

        [Fact(DisplayName = "Deve retornar verdadeiro quando um atributo existir em uma propriedade.")]
        [Trait("Category", "Extensions")]
        public void HasAttribute_BeTrue()
        {
            //Arrange
            var type = typeof(EnumTest);
            var memberInfo = type.GetMember(EnumTest.Valor1.ToString())[0];

            //Act
            var result = memberInfo.HasAttribute<DescriptionAttribute>();

            //Asset
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar falso quando um atributo não existir em uma propriedade.")]
        [Trait("Category", "Extensions")]
        public void HasAttribute_BeFalse()
        {
            //Arrange
            var type = typeof(EnumTest);
            var memberInfo = type.GetMember(EnumTest.Valor1.ToString())[0];

            //Act
            var result = memberInfo.HasAttribute<JsonAttribute>();

            //Assert
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve setar o valor de uma propriedade de setter privado quando o método for chamado.")]
        [Trait("Category", "Extensions")]
        public void SetPropertyValue()
        {
            var number = _faker.Random.Number(1, 100);
            var obj = new ObjectTest();

            obj.SetPropertyValue(p => p.Property1, number);

            obj.Property1.Should().Be(number);
        }

        [Fact(DisplayName = "Deve obter o valor de uma property privada quando a property informada existir no objeto.")]
        [Trait("Category", "Extensions")]
        public void GetPropertyValue_WhenHasProperty()
        {
            var number = _faker.Random.Number(1, 100);
            var obj = new ObjectTest { Property2 = number };

            var expectedValue = obj.GetPropertyValue("Property2");

            expectedValue.Should().Be(number);
        }

        [Fact(DisplayName = "Deve estourar uma exception quando a propriedade informada não existir no objeto.")]
        [Trait("Category", "Extensions")]
        public void GetPropertyValue_WhenHasNotField()
        {
            var number = _faker.Random.Number(1, 100);
            var obj = new ObjectTest { Property2 = number };

            obj.Invoking(o => o.GetPropertyValue($"{ Guid.NewGuid() }")).Should()
                .Throw<InvalidOperationException>()
                .WithMessage("The property provided does not exist.");
        }

        [Fact(DisplayName = "Deve setar o valor de um campo privado quando o método for chamado.")]
        [Trait("Category", "Extensions")]
        public void SetFieldValue()
        {
            var number = _faker.Random.Number(1, 100);
            var obj = new ObjectTest();

            obj.SetFieldValue("Field1", number);

            obj.GetField1().Should().Be(number);
        }

        [Fact(DisplayName = "Deve obter o valor de um campo privado quando o campo informado existir no objeto.")]
        [Trait("Category", "Extensions")]
        public void GetFieldValue_WhenHasField()
        {
            var number = _faker.Random.Number(1, 100);

            var obj = new ObjectTest();
            obj.SetField1(number);

            var result = obj.GetFieldValue("Field1");
            result.Should().Be(number);
        }

        [Fact(DisplayName = "Deve estourar uma exception quando o campo informado não existir no objeto.")]
        [Trait("Category", "Extensions")]
        public void GetFieldValue_WhenHasNotField()
        {
            var obj = new ObjectTest();

            obj.Invoking(o => o.GetFieldValue($"{ Guid.NewGuid() }")).Should()
                .Throw<InvalidOperationException>()
                .WithMessage("The field provided does not exist.");
        }
    }
}
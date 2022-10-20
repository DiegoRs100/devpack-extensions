using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Tests.Common.Helpers;
using Devpack.Extensions.Types;
using FluentAssertions;
using System;
using System.Text.Json;
using Xunit;

namespace Devpack.Extensions.Tests.Types
{
    public class ObjectExtensionsTests : UnitTestBase
    {
        [Fact(DisplayName = "Deve retornar verdadeiro quando um elemento existe dentro de uma lista.")]
        [Trait("Categoria", "Extensions")]
        public void In_BeTrue()
        {
            //Arrange
            var guid = Guid.NewGuid();

            //Act
            var result = guid.In(Guid.NewGuid(), guid, Guid.NewGuid());

            //Assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar falso quando um elemento não existe dentro de uma lista.")]
        [Trait("Categoria", "Extensions")]
        public void In_BeFalse()
        {
            //Arrange
            var guid = Guid.NewGuid();

            //Act
            var result = guid.In(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());

            //Assert
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar verdadeiro quando um elemento não existe dentro de uma lista.")]
        [Trait("Categoria", "Extensions")]
        public void NotIn_BeTrue()
        {
            //Arrange
            var guid = Guid.NewGuid();

            //Act
            var result = guid.NotIn(Guid.NewGuid(), Guid.NewGuid());

            //Assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar falso quando um elemento existe dentro de uma lista.")]
        [Trait("Categoria", "Extensions")]
        public void NotIn_BeFalse()
        {
            //Arrange
            var guid = Guid.NewGuid();

            //Act
            var result = guid.NotIn(guid, Guid.NewGuid());

            //Assert
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar objeto serializado quando um objeto válido for passado.")]
        [Trait("Categoria", "Extensions")]
        public void ToJson()
        {
            //Arrange
            var obj = new ObjectTest
            {
                Id = _faker.Random.Number(10, 100),
                Name = _faker.Random.Word()
            };

            var objSerialized = obj.ToJson();

            //Act
            var objAux = JsonSerializer.Deserialize<ObjectTest>(objSerialized);

            //Assert
            objAux.Should().BeEquivalentTo(obj);
        }

        [Fact(DisplayName = "Deve retornar true quando um objeto for nulo.")]
        [Trait("Categoria", "Extensions")]
        public void IsNull_BeTrue()
        {
            //Arrange
            object obj = null!;

            //Act
            var result = obj.IsNull();

            //Assert
            result.Should().BeTrue();
            DBNull.Value.IsNull().Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar false quando um objeto não for nulo.")]
        [Trait("Categoria", "Extensions")]
        public void IsNull_BeFalse()
        {   
            //Arrange
            object obj = "null";

            //Act
            var result = obj.IsNull();

            //Assert
            result.Should().BeFalse();
        }
    }
}

using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Tests.Common.Helpers;
using Devpack.Extensions.Types;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Devpack.Extensions.Tests.Types
{
    public class IEnumerableExtensionsTests : UnitTestBase
    {
        [Fact(DisplayName = "Deve retornar verdadeiro quando uma lista for nula.")]
        [Trait("Categoria", "Extensions")]
        public void IsNullOrEmpty_BeTrue_WhenNull()
        {
            //Arrange
            int[] list = null!;

            //Act
            var result = list.IsNullOrEmpty();

            //Assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar verdadeiro quando uma lista estiver vazia.")]
        [Trait("Categoria", "Extensions")]
        public void IsNullOrEmpty_BeTrue_WhenEmpty()
        {
            //Arrange
            var list = Array.Empty<int>();

            //Act
            var result = list.IsNullOrEmpty();

            //Assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar falso quando uma lista contiver valores.")]
        [Trait("Categoria", "Extensions")]
        public void IsNullOrEmpty_BeFalse()
        {
            //Arrange
            var list = _faker.Random.Bytes(10);

            //Act
            var result = list.IsNullOrEmpty();

            //Assert
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar uma lista contendo valores unicos quando uma lista com valores repetidos for passada.")]
        [Trait("Categoria", "Extensions")]
        public void Distinct()
        {
            //Arrange
            var item1 = _faker.Random.Word();
            var item2 = _faker.Random.Word();
            var item3 = _faker.Random.Word();

            var list = new KeyValuePair<int, string>[]
            {
                new KeyValuePair<int, string>(0, item1),
                new KeyValuePair<int, string>(0, item2),
                new KeyValuePair<int, string>(0, item1),
                new KeyValuePair<int, string>(0, item3),
                new KeyValuePair<int, string>(0, item3),
            };

            //Act
            var result = list.Distinct(l => l.Value);

            //Assert
            result.Should().HaveCount(3);
            result.Should().ContainSingle(l => l.Value == item1);
            result.Should().ContainSingle(l => l.Value == item2);
            result.Should().ContainSingle(l => l.Value == item3);
        }

        [Fact(DisplayName = "Deve retornar verdadeiro quando ao menos um dos valores indicados existe dentro de uma lista.")]
        [Trait("Categoria", "Extensions")]
        public void ContainsAny_BeTrue()
        {
            //Arrange
            var sourceWord = _faker.Random.Word();
            var list = new string[] { _faker.Random.Word(), sourceWord, _faker.Random.Word() };

            //Act
            var result = list.ContainsAny(sourceWord);

            //Assert
            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar falso quando nenhum dos valores indicados existe dentro de uma lista.")]
        [Trait("Categoria", "Extensions")]
        public void ContainsAny_BeFalse()
        {
            //Arrange
            var countWords = 2;
            var list = new string[] { _faker.Random.Word(), _faker.Random.Word(), _faker.Random.Word() };

            //Act
            var result = list.ContainsAny(_faker.Random.Words(countWords));

            //Assert
            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve retornar uma lista contendo apenas o objeto com maior valor quando uma lista válida é passada.")]
        [Trait("Categoria", "Extensions")]
        public void GroupByMaxValue()
        {
            //Arrange
            var count = 2;
            var key1 = Guid.NewGuid().ToString();
            var key2 = Guid.NewGuid().ToString();

            var list = new List<ObjectTest>();

            for (var i = 0; i < 4; i++)
                list.Add(new ObjectTest() { Name = key1, Count = _faker.Random.Number(1, 10) });

            for (var i = 0; i < 4; i++)
                list.Add(new ObjectTest() { Name = key2, Count = _faker.Random.Number(1, 10) });

            list.Add(new ObjectTest() { Name = key1, Count = 11 });
            list.Add(new ObjectTest() { Name = key2, Count = 11 });

            //Act
            var result = list.DistinctByMaxValue(o => o.Name, o => o.Count);

            //Assert
            result.Should().HaveCount(count);
            result.Should().Contain(o => o.Name == key1 && o.Count == 11);
            result.Should().Contain(o => o.Name == key2 && o.Count == 11);
        }

        [Fact(DisplayName = "Deve retornar verdadeiro quando uma lista é passada contendo dois valores chave duplicados.")]
        [Trait("Categoria", "Extensions")]
        public void IsDuplicated_BeTrue()
        {
            // Arrange
            var name = Guid.NewGuid().ToString();

            var list = new List<ObjectTest>()
            {
                new ObjectTest() { Name = name, Count = _faker.Random.Number(1, 10) },
                new ObjectTest() { Name = name, Count = _faker.Random.Number(1, 10) }
            };

            // Act
            var isDuplicated = list.IsDuplicated(o => o.Name);

            // Assert
            isDuplicated.Should().BeTrue();
        }

        [Fact(DisplayName = "Deve retornar falso quando uma lista é passada com todos os valores chave diferentes entre si.")]
        [Trait("Categoria", "Extensions")]
        public void IsDuplicated_BeFalse()
        {
            // Arrange
            var list = new List<ObjectTest>()
            {
                new ObjectTest() { Name = Guid.NewGuid().ToString(), Count = _faker.Random.Number(1, 10) },
                new ObjectTest() { Name = Guid.NewGuid().ToString(), Count = _faker.Random.Number(1, 10) }
            };

            // Act
            var isDuplicated = list.IsDuplicated(o => o.Name);

            // Assert
            isDuplicated.Should().BeFalse();
        }

        [Fact(DisplayName = "Deve executar e retornar uma ação para cada item da coleção")]
        [Trait("Categoria", "Extensions")]
        public void ForEach()
        {
            var enumerable = Enumerable.Range(0, 100);
            int count = 0;
            enumerable.ForEach(x =>
            {
                count++;
            });
            count.Should().Be(100);
        }
    }
}
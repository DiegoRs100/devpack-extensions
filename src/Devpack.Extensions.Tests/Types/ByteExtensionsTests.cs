using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Types;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Devpack.Extensions.Tests.Types
{
    public class ByteExtensionsTests : UnitTestBase
    {
        [Fact(DisplayName = "Deve gerar um hexadecimal quando passado um array de bytes.")]
        [Trait("Category", "Extensions")]
        public void ToHexadecimal()
        {
            //Arrange
            var bytes = _faker.Random.Bytes(20);
            var hexadecimal = bytes.ToHexadecimal();

            //Act
            var bytesAux = Enumerable.Range(0, hexadecimal.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hexadecimal.Substring(x, 2), 16))
                .ToArray();

            //Assert
            bytesAux.Should().BeEquivalentTo(bytes);
        }
    }
}
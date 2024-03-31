using Devpack.Extensions.Types;
using FluentAssertions;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Devpack.Extensions.Tests.Types
{
    public class StreamExtensionsTest
    {
        [Theory]
        [InlineData("Primeiro Texto para a Stream")]
        [InlineData("Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...")]
        [InlineData("Outro texto aleatório")]
        public async Task ReadAsStringAsync_WhenReadString(string text)
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
            var streamAsString = await stream.ReadAsStringAsync();

            text.Should().Be(streamAsString);
        }

        [Fact]
        public void ToMemoryStream_WhenNullValue()
        {
            string content = null!;
            using var memoryStream = content.ToMemoryStream();

            memoryStream.Length.Should().Be(0);
        }

        [Fact]
        public void ToMemoryStream_WhenValidObject()
        {
            var content = Guid.NewGuid().ToString();
            using var memoryStream = content.ToMemoryStream();

            var reader = new StreamReader(memoryStream);
            var result = reader.ReadToEnd();

            result.Should().Be(content);
        }
    }
}
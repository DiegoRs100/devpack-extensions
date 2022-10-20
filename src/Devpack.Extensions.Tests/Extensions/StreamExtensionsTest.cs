using Devpack.Extensions.Types;
using FluentAssertions;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Devpack.Extensions.Tests.Extensions
{
    public class StreamExtensionsTest
    {
        [Theory(DisplayName = "Deve retornar uma string de um Stream com o mesmo valor do parâmetro quando passado o valor em 'text'.")]
        [InlineData("Primeiro Texto para a Stream")]
        [InlineData("Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...")]
        [InlineData("Outro texto aleatório")]
        public async Task ReadToStringAsync_WhenReadString(string text)
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
            var streamAsString = await stream.ReadToStringAsync();

            text.Should().Be(streamAsString);
        }
    }
}
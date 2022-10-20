using Devpack.Extensions.Helpers;
using Devpack.Extensions.Tests.Common;
using FluentAssertions;
using Xunit;

namespace SiteMercado.Foundation.Extensions.Tests.Helpers
{
    public class UrlHelperTests : UnitTestBase
    {
        [Fact(DisplayName = "Deve formatar uma string bo padrão url quando ela for passada desnormalizada.")]
        [Trait("Categoria", "Helpers")]
        public void FormatToUrl_WhenSuccess()
        {
            var url = "Jornal DO--métrô";
            UrlHelper.UseEndpointFormat(url).Should().Be("jornal-do-metro");
        }

        [Theory(DisplayName = "Deve retornar uma string em branco quando ela for passada como nula ou vazia em 'url'.")]
        [Trait("Categoria", "Helpers")]
        [InlineData(Empty)]
        [InlineData(null)]

        public void FormatToUrl_WhenFail(string url)
        {
            UrlHelper.UseEndpointFormat(url).Should().Be(Empty);
        }

        [Fact(DisplayName = "Deve montar uma url quando diversos pedaços dela forem passados.")]
        [Trait("Categoria", "Helpers")]
        public void Combine()
        {
            var urlPrefix = _faker.Internet.Url();
            var urlPath1 = $"{_faker.Random.Word()}/";
            var urlPath2 = _faker.Random.Word();

            var combinatedUrl = UrlHelper.Combine(urlPrefix, urlPath1, urlPath2);
            combinatedUrl.Should().Be($"{ urlPrefix }/{ urlPath1[0..^2] }/{ urlPath2 }");
        }
    }
}
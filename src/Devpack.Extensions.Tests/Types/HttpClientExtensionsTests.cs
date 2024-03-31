using Bogus;
using FluentAssertions;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Devpack.Extensions.Types;
using RichardSzalay.MockHttp;
using Devpack.Extensions.Helpers;

namespace Devpack.Extensions.Tests.Types
{
    public class HttpClientExtensionsTests
    {
        [Fact]
        public async Task DeleteAsync_WhenSuccess()
        {
            // Arrange
            var faker = new Faker();
            var content = Guid.NewGuid();
            var cancellation = new CancellationToken();
            var urlPath = faker.Random.Word();
            var mockHttp = new MockHttpMessageHandler();

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri(faker.Internet.Url());

            var expextedRequest = mockHttp.When(HttpMethod.Delete, $"{client.BaseAddress}{urlPath}")
                .WithContent(await HttpClientHelper.ParseToStringContent(content).ReadAsStringAsync())
                .Respond(_ => new HttpResponseMessage());

            // Act
            await client.DeleteAsync(urlPath, HttpClientHelper.ParseToStringContent(content), cancellation);

            // Asserts
            mockHttp.GetMatchCount(expextedRequest).Should().Be(1);
        }
    }
}
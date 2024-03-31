using Devpack.Extensions.Helpers;
using FluentAssertions;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Devpack.Extensions.Tests.Types
{
    public class StringHelperTests
    {
        [Fact]
        public async Task ParseToStringContent_WhenSuccess()
        {
            var obj = Guid.NewGuid();

            var stringContent = HttpClientHelper.ParseToStringContent(obj);
            var expectedObj = JsonSerializer.Deserialize<Guid>(await stringContent.ReadAsStringAsync());

            obj.Should().Be(expectedObj);
        }
    }
}
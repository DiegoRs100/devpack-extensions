using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Types;
using FluentAssertions;
using System;
using Xunit;

namespace Devpack.Extensions.Tests.Types
{
    public class DateTimeExtensionsTests : UnitTestBase
    {
        [Fact]
        public void ConvertTimeToSouthAmericaZone_WhenSuccess()
        {
            var utcDate = DateTime.UtcNow;
            var localDate = utcDate.ConvertTimeToSouthAmericaZone();

            localDate.Should().Be(utcDate.Subtract(TimeSpan.FromHours(3)));
        }

        [Fact]
        public void ToOffsetString_WhenSuccess()
        {
            var now = new DateTime(2022, 10, 25, 18, 25, 53, 158, DateTimeKind.Local);
            var expectedStringDate = $"2022-10-25T18:25:53";

            var stringDate = now.ToOffsetString();

            stringDate.Should().Be(expectedStringDate);
        }
    }
}
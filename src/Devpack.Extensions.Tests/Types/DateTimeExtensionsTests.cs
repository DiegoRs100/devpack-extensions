using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Types;
using FluentAssertions;
using System;
using Xunit;

namespace Devpack.Extensions.Tests.Types
{
    public class DateTimeExtensionsTests : UnitTestBase
    {
        [Fact(DisplayName = "Deve retornar a data de acordo com o fuso horário de São Paulo " +
            "quando o método ConvertTimeToSouthAmericaZone for chamado.")]
        [Trait("Category", "Extensions")]
        public void ConvertTimeToSouthAmericaZone()
        {
            var utcDate = DateTime.UtcNow;
            var localDate = utcDate.ConvertTimeToSouthAmericaZone();

            localDate.Should().Be(utcDate.Subtract(TimeSpan.FromHours(3)));
        }
    }
}
using Devpack.Extensions.Helpers;
using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Tests.Common.Helpers;
using Devpack.Extensions.Types;
using FluentAssertions;
using System;
using Xunit;

namespace SiteMercado.Foundation.Extensions.Tests.Helpers
{
    public class EnumHelperTests : UnitTestBase
    {
        [Fact(DisplayName = "Deve retornar um enumerable quando o atributo do tipo 'Description' estiver presente no mesmo.")]
        [Trait("Categoria", "Helpers")]
        public void GetByDescription_WhenDescriptionAttribute()
        {
            var result = EnumHelper.GetByDescription<EnumTest>(EnumTest.Valor1.GetDescription());
            result.Should().Be(EnumTest.Valor1);
        }

        [Fact(DisplayName = "Deve retornar um enumerable quando uma das opções do enum tiver o nome igual ao nome buscado.")]
        [Trait("Categoria", "Helpers")]
        public void GetByDescription_WhenWithoutDescriptionAttribute()
        {
            var result = EnumHelper.GetByDescription<EnumTest>(nameof(EnumTest.Valor2));
            result.Should().Be(EnumTest.Valor2);
        }

        [Fact(DisplayName = "Deve retornar nulo quando o nome produrado não representar nenhuma das opções do enum.")]
        [Trait("Categoria", "Helpers")]
        public void GetByDescription_DeveRetornarNulo()
        {
            var result = EnumHelper.GetByDescription<EnumTest>(Guid.NewGuid().ToString());
            result.Should().BeNull();
        }
    }
}
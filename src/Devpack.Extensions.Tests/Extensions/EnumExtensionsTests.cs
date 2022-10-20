using Devpack.Extensions.Tests.Common;
using Devpack.Extensions.Tests.Common.Helpers;
using Devpack.Extensions.Types;
using FluentAssertions;
using Xunit;

namespace Devpack.Extensions.Tests.Extensions
{
    public class EnumExtensionsTests : UnitTestBase
    {
        [Fact(DisplayName = "Deve retornar a descrição do membro de um enum quando o atributo 'Description' está presente")]
        [Trait("Categoria", "Extensions")]
        public void GetDescription_ReturnsEnumMemberDescription()
        {
            var description = "Valor 1";
            var result = EnumTest.Valor1.GetDescription();

            result.Should().Be(description);
        }

        [Fact(DisplayName = "Deve retornar o nome do membro de um enum quando o atributo 'Description' não está presente")]
        [Trait("Categoria", "Extensions")]
        public void GetDescription_ReturnsEnumMemberName()
        {
            var description = nameof(EnumTest.Valor2);
            var result = EnumTest.Valor2.GetDescription();
            
            result.Should().Be(description);
        }
    }
}
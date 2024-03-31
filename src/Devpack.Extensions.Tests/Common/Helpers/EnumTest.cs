using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Devpack.Extensions.Tests.Common.Helpers
{
    public enum EnumTest
    {
        [Description("Valor 1")]
        Valor1 = 0,

        Valor2 = 1,

        [Display(Name = "Valor 3")]
        Valor3 = 2
    }
}
using Bogus;

namespace Devpack.Extensions.Tests.Common
{
    public abstract class UnitTestBase
    {
        public const string Empty = "";
        public const string Numbers = "0123456789";
        public const string Space = "   ";
        public const string AlphaNumeric = "dGs5##7ds85dssac1";
        public const string String = "dGscsdcD";
        public const string StringAndSpecialCharacteres = "dGs-dcsd!=cD*-a";
        public const string SpecialCharacteres = "##*!?-";
        public const string AllCharacteres = "dGs5##7  ds 85dss*-ac1 ";

        protected readonly Faker _faker;

        protected UnitTestBase()
        {
            _faker = new Faker("pt_BR");
        }
    }
}
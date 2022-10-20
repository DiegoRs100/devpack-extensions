using Bogus;

namespace Devpack.Extensions.Tests.Common
{
    public static class FakerExtensions
    {
        public static int NumberId(this Faker faker)
        {
            return faker.Random.Number(1, 10);
        }
    }
}
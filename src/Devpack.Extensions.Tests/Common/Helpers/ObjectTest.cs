namespace Devpack.Extensions.Tests.Common.Helpers
{
    public class ObjectTest
    {
        private int Field1;

        public int Id { get; set; }
        public string? Name { get; set; }
        public int Count { get; set; }

        public int Property1 { get; private set; }
        public int Property2 { private get; set; }

        public int GetField1()
        {
            return Field1;
        }

        public void SetField1(int field1)
        {
            Field1 = field1;
        }
    }
}
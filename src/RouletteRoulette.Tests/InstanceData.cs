using System.Reflection;
using Xunit.Sdk;

namespace RouletteRoulette.Tests
{
    internal class InstanceData<T> : DataAttribute where T : new()
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new T() };
        }
    }
}

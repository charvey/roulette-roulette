using System.Reflection;
using Xunit;

namespace RouletteRoulette.Tests
{
    public class BetterMemberData : MemberDataAttributeBase
    {
        public BetterMemberData(string memberName, params object[] parameters) : base(memberName, parameters)
        {
        }

        protected override object[] ConvertDataItem(MethodInfo testMethod, object item)
        {
            if (item.GetType() == typeof(object[]))
                return (object[])item;
            else
                return new[] { item };
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (MemberType == null && (testMethod.DeclaringType?.IsAbstract ?? false))
                MemberType = testMethod.ReflectedType;

            return base.GetData(testMethod);
        }
    }
}

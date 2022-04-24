//@CodeCopy
//MdStart
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CommonBase.Extensions
{
    public static partial class ReflectionExtensions
    {
        public static MethodBase GetAsyncOriginal(this MethodBase method)
        {
            var result = default(MethodBase);

            if (method.DeclaringType != null
                && method.DeclaringType.GetInterfaces().Any(i => i == typeof(IAsyncStateMachine)))
            {
                var generatedType = method.DeclaringType;
                var originalType = generatedType.DeclaringType;

                result = originalType?.GetMethods(BindingFlags.Instance
                                                  | BindingFlags.Static
                                                  | BindingFlags.Public
                                                  | BindingFlags.NonPublic
                                                  | BindingFlags.DeclaredOnly)
                                      .First(m => m.GetCustomAttribute<AsyncStateMachineAttribute>()?.StateMachineType == generatedType);
            }
            return result ?? method;
        }
    }
}
//MdEnd

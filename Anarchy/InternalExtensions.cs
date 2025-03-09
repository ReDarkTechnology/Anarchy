using System.Threading.Tasks;

namespace Discord
{
    internal static class InternalExtensions
    {
        public static void ToSync(this Task task) => task.GetAwaiter().GetResult();
        public static T ToSync<T>(this Task<T> task) => task.GetAwaiter().GetResult();
    }
}

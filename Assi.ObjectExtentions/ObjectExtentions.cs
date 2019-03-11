using System;
using System.Linq;
using System.Reflection;

namespace Assi.ObjectExtentions
{
    public static class ObjectExtentions
    {
        public static bool IsNullOrEmpty(this object obj)
        {
            return obj == null || String.IsNullOrWhiteSpace(obj.ToString());
        }

        public static bool HasAllPropertiesEmpty(this object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var hasProperty = properties.Select(x => x.GetValue(obj, null))
                                        .Any(x => !x.IsNullOrEmpty());
            return !hasProperty;
        }

        public static double PercentPropertiesFilled(this object obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var filledPropertiesCount = properties.Select(x => x.GetValue(obj, null))
                                        .Count(x => !x.IsNullOrEmpty());
            return 100 * (double)filledPropertiesCount / properties.Count();
        }
    }
}

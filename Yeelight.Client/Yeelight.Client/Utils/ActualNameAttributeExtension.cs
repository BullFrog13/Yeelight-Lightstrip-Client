using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Yeelight.Client.Utils
{
    internal static class ActualNameAttributeExtension
    {
        private static readonly Dictionary<Enum, string> CachedActualNames = new Dictionary<Enum, string>();

        public static string GetActualName(this Enum enumValue)
        {
            if (CachedActualNames.ContainsKey(enumValue))
            {
                return CachedActualNames[enumValue];
            }

            MemberInfo memberInfo = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();

            if (memberInfo != null)
            {
                var attribute =
                    (ActualNameAttribute) memberInfo.GetCustomAttributes(typeof(ActualNameAttribute), false)
                        .FirstOrDefault();

                if (attribute != null)
                {
                    CachedActualNames.TryAdd(enumValue, attribute.Name);

                    return attribute.Name;
                }
            }

            return null;
        }
    }
}
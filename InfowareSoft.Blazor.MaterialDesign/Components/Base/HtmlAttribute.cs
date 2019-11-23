using System;
using System.ComponentModel;
using System.Reflection;

namespace InfowareSoft.Blazor.MaterialDesign.Components.Base
{
    public class HtmlAttribute : Attribute
    {
        public HtmlAttribute(string name = null, string name2 = null)
        {
            Name = name;
            Name2 = name2;
        }

        public string Name { get; }
        public string Name2 { get; }
    }

    public static class HtmlAttributeHelper
    {
        public static string GetName<T>(this T enumValue) where T : struct
        {
            return enumValue.GetTypeName()?.Name;
        }

        public static string GetName2<T>(this T enumValue) where T : struct
        {
            return enumValue.GetTypeName()?.Name2;
        }

        public static HtmlAttribute GetTypeName<T>(this T enumValue) where T : struct
        {
            Type type = enumValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            MemberInfo[] memberInfo = type.GetMember(enumValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(HtmlAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((HtmlAttribute)attrs[0]);
                }
            }
            return null;
        }
    }

}
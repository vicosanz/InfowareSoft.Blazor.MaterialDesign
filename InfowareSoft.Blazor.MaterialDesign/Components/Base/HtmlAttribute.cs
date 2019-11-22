using System;
using System.ComponentModel;
using System.Reflection;

namespace InfowareSoft.Blazor.MaterialDesign.Components.Base
{
    public class HtmlAttribute : Attribute
    {
        public HtmlAttribute(string name = null)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public static class HtmlAttributeHelper
    {
        public static string GetName<T>(this T enumValue) where T : struct
        {
            return enumValue.GetTypeName()?.Name;
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
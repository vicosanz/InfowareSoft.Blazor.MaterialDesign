using System;
using System.ComponentModel;
using System.Reflection;

namespace InfowareSoft.Blazor.MaterialDesign.Components.Base
{
    public class HtmlAttribute : Attribute
    {
        public HtmlAttribute(string className = null, string rolName = null)
        {
            ClassName = className;
            RolName = rolName;
        }

        public string ClassName { get; }
        public string RolName { get; }
    }

    public static class HtmlAttributeHelper
    {
        public static string GetCssName<T>(this T enumValue) where T : struct
        {
            return enumValue.GetName()?.ClassName;
        }
        public static string GetRolName<T>(this T enumValue) where T : struct
        {
            return enumValue.GetName()?.RolName;
        }

        public static HtmlAttribute GetName<T>(this T enumValue) where T : struct
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
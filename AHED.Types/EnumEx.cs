using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AHED.Types
{
    static public class EnumEx
    {
        /// <summary>
        /// Extension method will get the description for any enumeration value.  If no
        /// description was provided, then <c>null</c> is returned.
        /// </summary>
        /// <param name="value">The enumeration value for which to get the description.</param>
        /// <returns>The string provided to the <c>DescriptionAttribute</c> of the enumeration.</returns>
        public static string GetDescription(this Enum value)
        {
            // If value is null or invalid for its base type, then return null.
            if (value == null || !Enum.IsDefined(value.GetType(), value))
                return null;

            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }

            // If we've reached this point, then this is a valid value, but no Description was provided.
            return null;
        }

        /// <summary>
        /// Gets the description of the enumerated value within the <c>enumType</c> enumeration.
        /// </summary>
        /// <param name="enumType">The type of the enumerated value specified by <c>name</c></param>
        /// <param name="name">The name of the enumerated value for which to get the description.</param>
        /// <returns></returns>
        public static string GetDescription(Type enumType, string name)
        {
            FieldInfo field = enumType.GetField(name);
            if (field != null)
            {
                DescriptionAttribute attr =
                       Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null)
                {
                    return attr.Description;
                }
            }

            return "<no description>";
        }

        /// <summary>
        /// Returns the first value for the enumeration specified by <c>type</c>.
        /// If <c>type</c> is not an enumeration, 0 is returned.
        /// </summary>
        /// <param name="type">The <c>Enum</c> type for which to determine the first value.</param>
        /// <returns>The first value for the <c>Enum</c> type provided.</returns>
        public static int First(Type type)
        {
            if (type.IsEnum == false)
                return 0;

            // This is definitely brute-force, but this should not be getting called very often
            var values = Enum.GetValues(type);
            Array.Sort(values);

            return (int)Enum.ToObject(type, values.GetValue(0));
        }

        /// <summary>
        /// Returns the last value for the enumeration specified by <c>type</c>.
        /// If <c>type</c> is not an enumeration, 0 is returned.
        /// </summary>
        /// <param name="type">The <c>Enum</c> type for which to determine the last value.</param>
        /// <returns>The last value for the <c>Enum</c> type provided.</returns>
        public static int Last(Type type)
        {
            if (type.IsEnum == false)
                return 0;

            // This is definitely brute-force, but this should not be getting called very often
            var values = Enum.GetValues(type);
            Array.Sort(values);

            return (int)Enum.ToObject(type, values.GetValue(values.Length - 1));
        }

        /// <summary>
        /// Returns the number of members in an enumeration, as well as the first and
        /// last values.
        /// <br/>
        /// <b>NOTE</b>: Is only correct for enumerations that are monotonically increasing
        /// by one from the first member to the last member.
        /// </summary>
        /// <param name="type">The <c>Enum</c> type for which to determine the last value.</param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public static int Range(Type type, out int first, out int last)
        {
            if (type.IsEnum == false)
            {
                first = 0;
                last = 0;
                return 0;
            }

            // This is definitely brute-force, but this should not be getting called very often
            var values = Enum.GetValues(type);
            Array.Sort(values);

            first = (int)Enum.ToObject(type, values.GetValue(0));
            last = (int)Enum.ToObject(type, values.GetValue(values.Length - 1));

            return values.Length;
        }

        /// <summary>
        /// Returns the number of values in an enumeration.
        /// </summary>
        /// <param name="type">The <c>Enum</c> type for which to determine the number of elements.</param>
        /// <returns>The number of values in the enumeration</returns>
        public static int Count(Type type)
        {
            if (type.IsEnum == false)
                return 0;

            var values = Enum.GetValues(type);

            return values.Length;
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GSRS.Infrastructure.Helpers
{
    /// <summary>
    /// Helper class to restrict null and empty inputs
    /// </summary>
    public static class Check
    {
        private const string ValidateExpression = @"^([a-zA-Z0-9_.]*-?[a-zA-Z0-9_.]+)";

        /// <summary>
        /// Guards for sql Injection in parameter
        /// </summary>
        /// <param name="input">The value.</param>
        public static void SqlInjection(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                Match m = Regex.Match(input, ValidateExpression);

                if (!m.Value.Equals(input))
                {
                    throw new ArgumentException("The Sort String has an Invalid value", input);
                }
            }
        }
        public static void DateValidations(DateTime? datestart, DateTime? dateend)
        {
            if (datestart >= dateend)
            {
                throw new ValidationException("End Date should be greater than start date");
            }
        }
        // public static void DateValidations<T>(T entity)
        // {
        //     DateTime startDate;
        //     DateTime endDate;
        //     PropertyInfo[] properties = typeof(T).GetProperties();
        //     foreach (PropertyInfo property in properties)
        //     {
        //         if (property.Name.ToLower() == "datestart")
        //         {
        //             startDate = (DateTime)property.GetValue(entity);
        //         }
        //         if (property.Name.ToLower() == "dateend")
        //         {
        //             endDate = (DateTime)property.GetValue(entity);
        //         }
        //     }
        //     // if (startDate != null && endDate != null)
        //     // {

        //         if (startDate >= endDate)
        //         {
        //             throw new ValidationException("End Date should be greater than start date");
        //         }
        //     // }
        // }
        public static void CheckModelProperties<T>(T model)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    string? value = property.GetValue(model) as string;
                    if (property.Name.ToLower() == "changedby" || property.Name.ToLower() == "comment")
                    {
                        continue;
                    }
                    else if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentNullException(property.Name);
                    }

                }
            }
        }
        /// <summary>
        /// Checks for null or empty string
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="value">The value.</param>
        /// <param name="isInnerProperty">if set to <c>true</c> [is inner property].</param>
        public static void NullOrEmpty(string paramName, string value, bool isInnerProperty = false)
        {
            if (string.IsNullOrEmpty(value))
            {
                if (isInnerProperty)
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} cannot be null or empty!", paramName), paramName);
                }
                else
                {
                    throw new ArgumentNullException(paramName);
                }
            }
        }

        /// <summary>
        /// Checks for null object.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="value">The value.</param>
        /// <param name="isInnerProperty">if set to <c>true</c> [is inner property].</param>
        public static void Null(string paramName, object value, bool isInnerProperty = false)
        {
            if (value == null)
            {
                if (isInnerProperty)
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} cannot be null!", paramName), paramName);
                }
                else
                {
                    throw new ArgumentNullException(paramName);
                }
            }
        }

        /// <summary>
        /// Checks for null or empty dictionary
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <typeparam name="U">U</typeparam>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="param">The param.</param>
        /// <param name="isInnerProperty">if set to <c>true</c> [is inner property].</param>
        public static void NullOrEmtpyDictionary<T, U>(string paramName, Dictionary<T, U> param, bool isInnerProperty = false)
        {
            if (param == null || param.Count < 1)
            {
                if (isInnerProperty)
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} cannot be null or empty!", paramName), paramName);
                }
                else
                {
                    throw new ArgumentNullException(paramName);
                }
            }
        }

        /// <summary>
        /// Checks for null or empty IEnumerable
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="value">The value.</param>
        /// <param name="isInnerProperty">if set to <c>true</c> [is inner property].</param>
        public static void NullOrEmptyEnumerable<T>(string paramName, IEnumerable<T> value, bool isInnerProperty = false)
        {
            if (value == null || !value.Any())
            {
                if (isInnerProperty)
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} cannot be null or empty!", paramName), paramName);
                }
                else
                {
                    throw new ArgumentNullException(paramName);
                }
            }
        }

        /// <summary>
        /// Checks for empty int
        /// </summary>
        /// <param name="paramName">parameter name</param>
        /// <param name="id">identifier</param>
        /// <param name="isInnerProperty">isInnerProperty</param>
        public static void Emptyint(string paramName, int id, bool isInnerProperty = false)
        {
            if (id <= 0)
            {
                if (isInnerProperty)
                {
                    throw new ArgumentException("Value cannot be int.Empty.", paramName);
                }
                else
                {
                    throw new ArgumentNullException(paramName);
                }
            }
        }
        // public static bool IsNotNullOrEmptyIEnumerable<T>(IEnumerable<T> value)
        // {
        //     return value != null && value.Any();
        // }
    }
}

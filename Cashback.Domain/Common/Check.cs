using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cashback.Domain.Common
{
    public static class Check
    {
        public static void Equals(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                throw new ArgumentException(message);
            }
        }

        public static void False(bool boolValue, string message)
        {
            if (boolValue)
            {
                throw new ArgumentException(message);
            }
        }

        public static void MaxLength(string stringValue, int maximum, string message)
        {
            var length = stringValue.Trim().Length;
            if (length > maximum)
            {
                throw new ArgumentException(message);
            }
        }

        public static void Length(string stringValue, int minimum, int maximum, string message)
        {
            var length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
            {
                throw new ArgumentException(message);
            }
        }

        public static void Match(string pattern, string stringValue, string message)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(stringValue))
            {
                throw new ArgumentException(message);
            }
        }

        public static void NotEmpty(string stringValue, string message)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                throw new ArgumentException(message);
            }
        }

        public static void NotEmpty(Guid guidValue, string message)
        {
            if (guidValue == default)
            {
                throw new ArgumentException(message);
            }
        }

        public static void NotEmpty<T>(IEnumerable<T> collection, string message)
        {
            if (collection != null && collection.Any())
            {
                return;
            }
            throw new ArgumentException(message);
        }

        public static void NotEqual(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                throw new ArgumentException(message);
            }
        }

        public static void NotNull(object object1, string message)
        {
            if (object1 == null)
            {
                throw new ArgumentException(message);
            }
        }

        public static void IsInRange(double value, double minimum, double maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new ArgumentException(message);
            }
        }

        public static void IsInRange(float value, float minimum, float maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new ArgumentException(message);
            }
        }

        public static void IsInRange(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new ArgumentException(message);
            }
        }

        public static void IsInRange(long value, long minimum, long maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new ArgumentException(message);
            }
        }

        public static void IsInRange(DateTime value, DateTime minimum, DateTime maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new ArgumentException(message);
            }
        }

        public static void True(bool boolValue, string message)
        {
            if (!boolValue)
            {
                throw new ArgumentException(message);
            }
        }
    }
}

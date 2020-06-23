using System;
using System.Collections.Generic;
using System.Linq;

namespace Cashback.Domain.Common
{
    public class Cpf
    {
        private readonly string _pattern = @"\d{11}$";
        private readonly int[] _weights = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        #region Properties
        private string _value;
        public string Value
        {
            get { return _value; }
            private set
            {
                Check.NotNull(value, "CPF can't be null");
                Check.True(IsValid(value), "Invalid CPF");

                _value = value;
            }
        }
        #endregion

        public Cpf(string cpf)
        {
            Value = cpf.Sanitize(".-");
        }

        private bool IsValid(string cpf)
        {
            Check.Match(_pattern, cpf, "Invalid CPF.");
            Check.Length(cpf, 11, 11, "CPF must be 11 digits length.");

            var digits = cpf.ToCharArray().Select(d => int.Parse(d.ToString()));
            var knownDigits = digits.Take(9).ToList();
            var validationDigit = digits.Skip(9);

            var firstDigit = Digit(knownDigits, _weights.Skip(1));
            knownDigits.Add(firstDigit);

            var secondVerificationDigit = Digit(knownDigits, _weights);

            return validationDigit
                .SequenceEqual(new int[] { firstDigit, secondVerificationDigit });
        }

        private static int Digit(IEnumerable<int> knownDigits, IEnumerable<int> weights)
        {
            var sum = knownDigits.Zip(weights, (digit, weight) => digit * weight).Sum();
            return (11 - sum % 11) > 9 ? 0 : (11 - sum % 11);
        }

        public static string ApplyMask(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return string.Empty;
            }
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }
    }
}

using System;

namespace Cashback.Domain.Common
{
    public class Email : IComparable<Email>
    {
        private readonly string _regexPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        #region Properties
        private string _address;

        public string Address
        {
            get { return _address; }
            private set
            {
                if (!string.IsNullOrEmpty(value))
                    Check.Match(_regexPattern, value, "O email deve válido.");

                _address = value;
            }
        }
        #endregion
        public Email(string email)
        {
            Address = email;
        }

        #region Equals() and GetHashCode() overrides
        public override bool Equals(object obj)
        {
            var other = obj as Email;

            if (other == null)
            {
                return false;
            }
            return Address == other.Address;
        }

        public override int GetHashCode()
        {
            return Address.GetHashCode();
        }
        #endregion

        #region IComparable implementation
        public int CompareTo(Email other)
        {
            return Address.CompareTo(other.Address);
        }
        #endregion
    }
}

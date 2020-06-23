using Cashback.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cashback.UnitTest.Common
{
    [Trait("Email Tests", "email_tests")]
    public class EmailTests
    {
        [Fact(DisplayName = "Valid email address succeeds.")]
        public void Email_Must_Be_Valid()
        {
            Assert.NotNull(new Email("test@test.com"));
            Assert.NotNull(new Email("test.10@test.com"));
            Assert.NotNull(new Email("test@test.com.br"));
            Assert.NotNull(new Email("test@123.com"));
        }

        [Fact(DisplayName = "Valid email address GetHashCode.")]
        public void Email_Must_Be_GetHashCode()
        {
            var hashOrigen = "test@test.com".GetHashCode();
            var hashEmail = new Email("test@test.com").GetHashCode();
            Assert.Equal(hashOrigen, hashEmail);

        }

        [Fact(DisplayName = "Invalid email throws a exception.")]
        public void Invalid_Email_Throws_A_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Email("test@test."));
            Assert.Throws<ArgumentException>(() => new Email("test.10@test"));
            Assert.Throws<ArgumentException>(() => new Email("test"));
        }

        [Fact(DisplayName = "Equals() returns 'true' when comparing two Email instances with identical addresses.")]
        public void Equals_Succeeds_Comparing_Identical_Addresses()
        {
            Assert.True(new Email("user@gmail.com").Equals(new Email("user@gmail.com")));
        }

        [Fact(DisplayName = "Equals() returns 'false' when comparing different email addresses.")]
        public void Equals_Succeeds_Comparing_Different_Addresses()
        {
            Assert.False(new Email("user@gmail.com").Equals(new Email("johndoe@gmail.com")));
            Assert.False(new Email("user@gmail.com").Equals(null));
        }

        [Fact(DisplayName = "Email is sorteable.")]
        public void Email_Is_Sorteable()
        {
            var email11 = new Email("email_11@email.com");
            var email10 = new Email("email_10@email.com");
            var email9 = new Email("email_9@email.com");
            var email13 = new Email("email_13@email.com");
            var email1 = new Email("email_1@email.com");

            var list = new List<Email>() { email11, email10, email9, email13, email1 };
            var sortedList = new List<Email>() { email1, email10, email11, email13, email9 };

            list = list.OrderBy(e => e).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                Assert.True(list[i].Equals(sortedList[i]));
            }
        }
    }
}

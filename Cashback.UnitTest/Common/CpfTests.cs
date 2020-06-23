using Cashback.Domain.Common;
using System;
using Xunit;

namespace Cashback.UnitTest.Common
{
    [Trait("CPF Tests", "cpf_tests")]
    public class CpfTests
    {
        [Fact(DisplayName = "Valid CPF")]
        public void Valid_CPF()
        {
            Assert.NotNull(new Cpf("877.483.083-06").Value);
            Assert.NotNull(new Cpf("87748308306").Value);
            Assert.NotNull(new Cpf("797.152.414-50").Value);
            Assert.NotNull(new Cpf("058.810.825-16").Value);
            Assert.NotNull(new Cpf("728.893.454-32").Value);
        }

        [Fact(DisplayName = "Invalid CPF")]
        public void Invalid_CPF()
        {
            Assert.Throws<ArgumentException>(() => new Cpf("877.483.083-07"));
            Assert.Throws<ArgumentException>(() => new Cpf("877.483.083-0"));
            Assert.Throws<ArgumentException>(() => new Cpf(string.Empty));
            Assert.Throws<ArgumentException>(() => new Cpf(null));
        }

        [Fact(DisplayName = "Apply mask on CPF")]
        public void ApplyMask()
        {
            Assert.Equal("877.483.083-06", Cpf.ApplyMask(new Cpf("87748308306").Value));
        }
    }
}

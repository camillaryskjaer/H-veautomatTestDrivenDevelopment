using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HæveautomatTestDrivenDevelopment;
using HæveautomatTestDrivenDevelopment.ATM;
using Xunit;
using System.IO;

namespace Hæveautomat.Tests
{
    public class LoginTests
    {
        //checks pincode for failures
        [Theory]
        [InlineData("476")]
        [InlineData("abcd")]
        [InlineData("63427")]
        [InlineData("FemSyvTiTo")]
        public void Login_ShouldNotWork(string pincode)
        {
            Assert.Equal(null, ATM.Login(pincode).Pincode);
        }

        //checks if pincode works
        [Theory]
        [InlineData("0000")]
        public void Login_ShouldWork(string pincode)
        {
            Assert.True(ATM.Login(pincode).GetType() == typeof(Account));
            Assert.Equal(pincode, ATM.Login(pincode).Pincode);
        }
    }
}

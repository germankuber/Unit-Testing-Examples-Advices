using ExamplesAdvices.Core;
using FluentAssertions;
using Xunit;

namespace ExamplesAdvices.Tests
{
    public class UserControllerShould
    {
        [Fact]
        public void Return_True_User_Logged_Successfully()
        {
            var sut = new UserController(new UserServices(new EmailService()), new ReverseEncryption());

            var user = new UserProfile(
                userName: "userName",
                lastName: "LastName",
                firstName: "FirstName",
                password: "Password",
                rePassword: "Password");

            var result = sut.Login(user);

            result.Should().BeTrue();

        }

        [Fact]
        public void Return_False_User_Does_Not_Logged_Successfully()
        {
            var sut = new UserController(new UserServices(new EmailService()), new ReverseEncryption());

            var user = new UserProfile(
                userName: "userName",
                lastName: "LastName",
                firstName: "FirstName",
                password: "Password",
                rePassword: "Re Password");

            var result = sut.Login(user);

            result.Should().BeFalse();

        }
        [Fact]
        public void Return_False_User_Does_Not_Logged_Does_Not_Have_FirstName_LastName()
        {
            var sut = new UserController(new UserServices(), new ReverseEncryption());

            var user = new UserProfile
            {
                UserName = "userName",
                Password = "Password",
                RePassword = "Re Password"
            };

            var result = sut.Login(user);

            result.Should().BeFalse();

        }
    }
}

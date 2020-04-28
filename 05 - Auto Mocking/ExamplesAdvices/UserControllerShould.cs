using System;
using ExamplesAdvices.Core;
using FluentAssertions;
using Xunit;

namespace ExamplesAdvices.Tests
{
    public class UserControllerShould : IDisposable
    {


        [Fact]
        public void Return_True_User_Logged_Successfully()
        {
            //TODO : 03 - Utilizo Builder
            var sut = new UserControllerBuilder()
                .WithUserService(new UserServices(new EmailService()))
                .Build();

            var user = new UserProfileBuilder()
                .Build();

            var result = sut.Login(user);

            result.Should().BeTrue();

        }

        [Fact]
        public void Return_False_User_Does_Not_Logged_Successfully()
        {
            //TODO : 02 - Utilizo Builder
            var sut = new UserControllerBuilder()
                .WithRealServices(new UserServices(new EmailService()), new ReverseEncryption())
                .Build();

            var userTest = new UserProfileBuilder()
                                            .WithNonMatchingPasswords()
                                            .Build();

            var result = sut.Login(userTest);

            result.Should().BeFalse();

        }
        [Fact]
        public void Return_False_User_Does_Not_Logged_Does_Not_Have_FirstName_LastName()
        {

            var sut = new UserControllerBuilder().Build();

            UserProfile user = new UserProfileBuilder()
                .WithFirstName(string.Empty)
                .WithoutNames();


            var result = sut.Login(user);

            result.Should().BeFalse();

        }

        public void Dispose()
        {
            //Clean Code
        }

    }
}

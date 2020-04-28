using System;
using ExamplesAdvices.Core;
using FluentAssertions;
using Xunit;

namespace ExamplesAdvices.Tests
{
    public class UserControllerShould : IDisposable
    {
        //private readonly Mock<IEncryption> _encryption;
        //private readonly Mock<IUserServices> _userService;
        //private readonly Mock<IEmailService> _emailService;


        public UserControllerShould()
        {
            //_userService = new Mock<IUserServices>();
            //_emailService = new Mock<IEmailService>();
            //_encryption = new Mock<IEncryption>();
        }
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
            //var sut = CreateSutWithRealDependencies();
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
        }

        //private UserController CreateSutWithRealDependencies() =>
        //    new UserController(new UserServices(new EmailService()), new ReverseEncryption());

        //private UserController CreateSutWithRealDependenciesWithoutEmail() =>
        //    new UserController(new UserServices(_emailService.Object), new ReverseEncryption());

        //private UserController CreateSut() =>
        //    new UserController(_userService.Object, _encryption.Object);
    }
}

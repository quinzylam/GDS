using NUnit.Framework;
using GDS.Resources;
using GDS.MockFactory;
using GDS.Core.Services;
using GDS.Core.Models.Administration;
using Moq;

namespace GDS.Mobile.ViewModels.Tests
{
    [TestFixture()]
    public class LoginViewModelTests
    {
        [Test()]
        public void LoginViewModelTest()
        {
            //Setup
            LoginViewModel vm = SetupLogin();

            //Assert
            Assert.IsNotNull(vm);
            Assert.AreEqual(GDSResource.LoginTitle, vm.Title);
        }

        private static LoginViewModel SetupLogin()
        {
            SUT.Setup();
            return SUT.Mock.Create<LoginViewModel>();
        }

        [Test()]
        public void CanGetUserTest()
        {
            var vm = SetupLogin();
            vm.Username = "Admin";

            var result = vm.CanGetUser();

            Assert.IsTrue(result);
        }

        [TestCase("")]
        public void CanGetUser_Fail(string username)
        {
            var vm = SetupLogin();
            vm.Username = username;

            var result = vm.CanGetUser();

            Assert.IsFalse(result);
            Assert.AreEqual(string.Concat(nameof(vm.Username), GDSResource.EmptyError), vm.ErrorMsg);
        }

        [Test()]
        public void GetUserTest()
        {
            var vm = SetupLogin();
            vm.Username = "Admin";

            vm.GetUserCommand.Execute(null);

            SUT.Mock.Mock<ISecurityService<User>>().Verify(ifc => ifc.GetUserAsync(vm.Username), Times.Once);
        }

        [Test()]
        public void CanLoginTest()
        {
            var vm = SetupLogin();
            vm.Username = "Admin";
            vm.Password = "ADMIN";

            var result = vm.CanGetUser();

            Assert.IsTrue(result);
        }

        [Test()]
        public void LoginTest()
        {
            var vm = SetupLogin();
            vm.Username = "Admin";
            vm.Password = "ADMIN";
            bool loggedIn = false;
            vm.OnLogin += (o, e) => loggedIn = true;

            vm.LoginCommand.Execute(null);

            SUT.Mock.Mock<ISecurityService<User>>().Verify(ifc => ifc.LoginAsync(vm.Password), Times.Once);
            Assert.IsTrue(loggedIn);
        }
    }
}
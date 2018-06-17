using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Danishevskii.Nitka.Dto;
using Danishevskii.Nitka.Model.Interfaces;
using Danishevskii.Nitka.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Danishevskii.Nitka.Tests
{
    [TestClass]
    public class UserControllerTest
    {
 
        [TestMethod]
        public void Get_ReturnRightUsersCount()
        {
            //ARRAGE
            var testRequest = new PageRequest() { PageCount = 10, PageNumber=2 };
            var testResponse = new PageResponse(new List<UserDto>() { new UserDto(), new UserDto() }, 1);
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(c => c.GetUsers(It.IsAny<PageRequest>())).Returns(testResponse); 
            
            var userController = new UserController(userServiceMock.Object);

            //ACT
            var result = userController.Get(10, 2);
            //ASSERT
            Assert.AreEqual(result.Data.Count(), 2);
        }

        [TestMethod]
        public void Delete_BadId_NonFount()
        {
            //ARRAGE
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(c => c.DeleteUser(It.IsAny<Guid>()));

            var userController = new UserController(userServiceMock.Object);

            //ACT
            var result = userController.Delete(new Guid());
            //ASSERT
            Assert.IsInstanceOfType(result, typeof(NotFoundResult)); 
        }

        [TestMethod]
        public void Delete_OkId_DeleteUser()
        {
            //ARRAGE
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(c => c.DeleteUser(It.IsAny<Guid>()));

            var userController = new UserController(userServiceMock.Object);

            //ACT
            var result = userController.Delete(Guid.NewGuid());
            //ASSERT
            userServiceMock.Verify(c=>c.DeleteUser(It.IsAny<Guid>()), Times.Once());
        }
    }
}

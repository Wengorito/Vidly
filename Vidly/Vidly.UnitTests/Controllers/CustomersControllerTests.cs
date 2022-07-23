using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using Vidly.Controllers;
using Vidly.Core;
using Vidly.Core.Domain;

namespace Vidly.UnitTests.Controllers
{
    [TestFixture]
    public class CustomersControllerTests
    {
        private Mock<IUnitOfWork> _dbContext;

        [SetUp]
        public void Setup()
        {
            _dbContext = new Mock<IUnitOfWork>();
        }

        [Test]
        public void Details_CustomerIsNull_ReturnHttpNotFound()
        {
            _dbContext.Setup(c => c.Customers.GetSingleWithMembershipType(It.IsAny<int>())).Returns((Customer)null);

            var controller = new CustomersController(_dbContext.Object);

            var result = controller.Details(1);

            Assert.That(result, Is.TypeOf<HttpNotFoundResult>());
        }

        [Test]
        public void Details_CustomerExists_ReturnView()
        {
            _dbContext.Setup(c => c.Customers.GetSingleWithMembershipType(It.IsAny<int>())).Returns(new Customer());

            var controller = new CustomersController(_dbContext.Object);

            var result = controller.Details(1);

            Assert.That(result, Is.TypeOf<ViewResult>());
        }
    }
}
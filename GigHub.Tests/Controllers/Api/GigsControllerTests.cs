using FluentAssertions;
using GigHub.Tests.Extensions;
using GigHub1.Controllers.Api;
using GigHub1.Core;
using GigHub1.Core.Models;
using GigHub1.Core.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;

namespace GigHub1.Tests.Controllers.Api
{

    [TestClass]
    public class GigsControllerTests
    {
        private GigsController _controller;
        private Mock<IGigRepository> _mockRepository;
        private string _userId;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IGigRepository>();

            var MockUoW = new Mock<IUnitOfWork>();

            MockUoW.SetupGet(u => u.Gigs).Returns(_mockRepository.Object);

            _controller = new GigsController(MockUoW.Object);

            _userId = "1";

            _controller.MockCurrentUser(_userId, "user@domain.com");
        }
        [TestMethod]
        public void Cancel_NoGigWithGivenIdExists_ShouldReturnNotFound()
        {
            var result = _controller.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void Cancel_GigIsCanceled_ShoulReturnNotFound()
        {
            var gig = new Gig();
            gig.Cancel();

            _mockRepository.Setup(r => r.GetGigsWithAttendees(1)).Returns(gig);

            var result = _controller.Cancel(1);
            result.Should().BeOfType<NotFoundResult>();
        }
        [TestMethod]
        public void Cancel_UserCancelingAnotherUserGig_ShouldReturnUnauthorized()
        {
            var gig = new Gig { ArtistId = _userId + "-" };
            _mockRepository.Setup(r => r.GetGigsWithAttendees(1)).Returns(gig);

            var result = _controller.Cancel(1);
            result.Should().BeOfType<UnauthorizedResult>();

        }
        [TestMethod]
        public void Cancel_ValidRequest_ShouldReturnOk()
        {
            var gig = new Gig { ArtistId = _userId  };
            _mockRepository.Setup(r => r.GetGigsWithAttendees(1)).Returns(gig);

            var result = _controller.Cancel(1);
            result.Should().BeOfType<OkResult>();

        }
    }
}

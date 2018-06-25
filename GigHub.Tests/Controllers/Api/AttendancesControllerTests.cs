using System;
using System.Web.Http.Results;
using FluentAssertions;
using GigHub.Tests.Extensions;
using GigHub1.Controllers.Api;
using GigHub1.Core;
using GigHub1.Core.Models;
using GigHub1.Core.Repositories;
using GigHub1.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GigHub.Tests.Controllers.Api
{
    [TestClass]
    public class AttendancesControllerTests
    {
        private AttendancesController _controller;
        private Mock<IAttendanceRepository> _mockRepository;
        private string _userId;
        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IAttendanceRepository>();

            var MockUoW = new Mock<IUnitOfWork>();

            MockUoW.SetupGet(u => u.Attendances).Returns(_mockRepository.Object);

            _controller = new AttendancesController(MockUoW.Object);

            _userId = "1";

            _controller.MockCurrentUser(_userId, "user@domain.com");
        }

        [TestMethod]
        public void Attend_UserAttendingAGigForWhichHeHasAttendance_ShouldReturnBadRequest()
        {
            var attendance = new Attendance();
            _mockRepository.Setup(r => r.GetAttendance(1, _userId)).Returns(attendance);
            var result = _controller.Attend(new AttendanceDto { GigId = 1 });
            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }

        [TestMethod]
        public void Attend_ValidRequest_ShouldReturnOk()
        {
            var result = _controller.Attend(new AttendanceDto { GigId = 1 });
            result.Should().BeOfType<OkResult>();
        }
        [TestMethod]
        public void DeleteAttendance_NoAttendanceWithGivenExists_ShouldReturnNotFound()
        {
            var result = _controller.DeleteAttendances(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public void DeleteAttendance_ValidRequest_ShouldReturnIdOrDeleteAttendance()
        {
            var attendance = new Attendance();
            _mockRepository.Setup(r => r.GetAttendance(1, _userId)).Returns(attendance);
            var result = (OkNegotiatedContentResult<int>)_controller.DeleteAttendances(1);
            result.Content.Should().Be(1);
        }
    }
}

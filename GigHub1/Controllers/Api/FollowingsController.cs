using GigHub1.Core;
using GigHub1.Core.Models;
using GigHub1.Dtos;
using GigHub1.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub1.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
       
        private IUnitOfWork _unitOfWork;
        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            var following = _unitOfWork.Followings.GetFollowing(userId, dto.FolloweeId);

            if (following != null)
                return BadRequest("Following already exists.");

             following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _unitOfWork.Followings.Add(following);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult UnFollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = _unitOfWork.Followings.GetFollowing(userId, id);
            if (following == null)
                return NotFound();

            _unitOfWork.Followings.Remove(following);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}

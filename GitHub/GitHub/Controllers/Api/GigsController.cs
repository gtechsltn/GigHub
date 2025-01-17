﻿using GigHub.Core;
using GigHub.Persistence;
using GitHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Security.Principal;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [HttpDelete]
        public IHttpActionResult Cancel(int Id)
        {
            var userId = User.Identity.GetUserId();

            var gig = _unitOfWork.Gigs.GetGigWithAttendees(Id);

            if (gig == null || gig.IsCanceled)
                return NotFound();
            
            if (gig.ArtistId != userId)
                return Unauthorized();

            gig.Cancel();
            _unitOfWork.Complete();

            return Ok();

        }
    }
}

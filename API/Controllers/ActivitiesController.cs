using Microsoft.AspNetCore.Mvc;
using Domain;
using Application.Activities.Queries;
using Application.Activities.Commands;

namespace API.Controllers;

    public class ActivitiesController : BaseAPIController
    {

        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new GetActivityList.Query());
            //return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] //api/activities/fdkfdffdfd
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new GetActivityDetails.Query{ Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateActivity(Activity activity)
        {
            return await Mediator.Send(new CreateActivity.Command{ Activity = activity });
        }

        [HttpPut]
        public async Task<ActionResult> EditActivity(Activity activity)
        {
            await Mediator.Send(new EditActivity.Command{ Activity = activity });

            return NoContent();
        }
    }
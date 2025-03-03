using System;
using MediatR;
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
        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            return await Mediator.Send(new GetActivityDetails.Query{Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(Activity activity)
        {
            return await Mediator.Send(new CreateActivity.Command{Activity = activity});
        }

        [HttpPut]
        public async Task<ActionResult> EditActivity(Activity activity)
        {
            await Mediator.Send(new EditActivity.Command{Activity = activity});

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(string id)
        {
            await Mediator.Send(new DeleteActivity.Command{Id = id});

            return Ok();
        }
    }
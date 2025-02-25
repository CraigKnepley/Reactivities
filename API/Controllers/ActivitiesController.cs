using Microsoft.AspNetCore.Mvc;
using Domain;
using Persistence;
using MediatR;
using Application.Activities.Queries;

namespace API.Controllers
{
    public class ActivitiesController : BaseAPIController
    {
        private readonly DataContext _context;
        private readonly IMediator _mediator;

        public ActivitiesController(DataContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet] //api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _mediator.Send(new GetActivityList.Query());
            //return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")] //api/activities/fdkfdffdfd
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _mediator.Send(new GetActivityDetails.Query{Id = id });
        }
    }    
}
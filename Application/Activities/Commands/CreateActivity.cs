using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

    public class CreateActivity
    {
        public class Command : IRequest<Guid>
        {
            public required Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command, Guid>
        {
            private readonly DataContext _context; 
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);

                await _context.SaveChangesAsync(cancellationToken);

                return request.Activity.Id;
            }
        }
    }

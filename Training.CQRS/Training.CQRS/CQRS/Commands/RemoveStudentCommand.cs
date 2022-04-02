using MediatR;

namespace Training.CQRS.CQRS.Commands
{
    public class RemoveStudentCommand : IRequest
    {
        public RemoveStudentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

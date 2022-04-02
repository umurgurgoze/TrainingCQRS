using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.CQRS.CQRS.Commands;
using Training.CQRS.CQRS.Handlers;
using Training.CQRS.CQRS.Queries;
// YORUM SATIRLARI İLK KULLANIM. DAHA SONRA MediatR İLE YAPTIK. Startup, Controller, CQRS içerisinde yorum satırları var.Bunlar ilk 
//kullanım. En son çalışanlar MediatR ile yapıldı.
namespace Training.CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        //private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
        //private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
        //private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        //private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        //private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;
        //public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        //{
        //    _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
        //    _getStudentsQueryHandler = getStudentsQueryHandler;
        //    _createStudentCommandHandler = createStudentCommandHandler;
        //    _removeStudentCommandHandler = removeStudentCommandHandler;
        //    _updateStudentCommandHandler = updateStudentCommandHandler;
        //}

        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStudentsQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            await _mediator.Send(command);
            return Created("", command.Name);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();
        }

        //[HttpGet("{id}")]
        //public IActionResult GetStudent(int id)
        //{
        //    var result = _getStudentByIdQueryHandler.Handle(new GetStudentByIdQuery(id));
        //    return Ok(result);
        //}
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var result = _getStudentsQueryHandler.Handle(new GetStudentsQuery());
        //    return Ok(result);
        //}
        //[HttpPost]
        //public IActionResult Create(CreateStudentCommand command)
        //{
        //    _createStudentCommandHandler.Handle(command);
        //    return Created("",command.Name);
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Remove(int id)
        //{
        //    _removeStudentCommandHandler.Handle(new RemoveStudentCommand(id));
        //    return NoContent();
        //}
        //[HttpPut]
        //public IActionResult Update(UpdateStudentCommand command)
        //{
        //    _updateStudentCommandHandler.Handle(command);
        //    return NoContent();
        //}
    }
}

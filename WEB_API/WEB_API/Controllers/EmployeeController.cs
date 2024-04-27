using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB_API.Model;
using WEB_API.ViewModel;

namespace WEB_API.Controllers
{
    [ApiController]
    [Route("api/v1/employee")] 
    public class EmployeeController : ControllerBase
    {
        
        private readonly IEmployeeRepository _employeeRepository;

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize] 
        [HttpGet]
        public IActionResult Get() 
        {
            
            _logger.Log(LogLevel.Error, "Teve um erro");

            var employee = _employeeRepository.GetAll();

            _logger.LogInformation("Teste de log");

            return Ok(employee);
        }

        [Authorize]
        [HttpGet]
        [Route("/paginacao")] 
        public IActionResult GetAllFilter(int pageNumber, int pageQuantity)
        {
            var employess = _employeeRepository.GetAllPag(pageNumber, pageQuantity);

            return Ok(employess);
        }

        [Authorize] 
        [HttpPost]
        public IActionResult Add([FromForm]EmployeeViewModel employeeView)
        {  
            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);

            _employeeRepository.Add(employee);

            return Ok();
        }

        [Authorize] 
        [HttpPost]
        [Route("{id}/download")] 
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");
        }


        

    }
}

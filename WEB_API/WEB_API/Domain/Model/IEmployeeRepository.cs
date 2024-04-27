using WEB_API.Domain.DTOs;

namespace WEB_API.Domain.Model
{
    public interface IEmployeeRepository
    {
        // Metodos
        void Add(Employee employee);

        List<Employee> GetAll();

        //[8] alterando a list de Employee para EmployeeDTO
        List<EmployeeDTO> GetAllPag(int pageNumber, int pageQuantity);

        Employee? Get(int id);
    }
}

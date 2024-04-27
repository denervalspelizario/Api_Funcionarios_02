namespace WEB_API.Model
{
    public interface IEmployeeRepository
    {
        // Metodos
        void Add(Employee employee); 

        List<Employee> GetAll(); 

       
        List<Employee> GetAllPag(int pageNumber, int pageQuantity);

        Employee? Get(int id); 
    }
}

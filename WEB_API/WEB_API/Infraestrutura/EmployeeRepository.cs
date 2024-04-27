using WEB_API.Model;

namespace WEB_API.Infraestrutura
{
    
    public class EmployeeRepository : IEmployeeRepository
    {
         
        private readonly ConnectionContext _context = new ConnectionContext();
        
        
        public void Add(Employee dadoFuncioanrio)
        {
             
            _context.Employees.Add(dadoFuncioanrio);

            
            _context.SaveChanges();
        }


        public List<Employee> GetAll()
        {
            
            return _context.Employees.ToList();
        }

        
        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }


        
        public List<Employee> GetAllPag(int pageNumber, int pageQuantity)
        {
            
            return _context.Employees.Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
            
        }
    }
}

using WEB_API.Domain.DTOs;
using WEB_API.Domain.Model;

namespace WEB_API.Infraestrutura.Repositoy
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


        /* [8] como alterei a List de Employee para EmployeeDTO o _context precisa ser 
               reajustado */
        public List<EmployeeDTO> GetAllPag(int pageNumber, int pageQuantity)
        {
            /*[8] O erro esta pq ela esta retornando uma entidade e na verdade
             * precisa retornar uma dto e para isso vamos usar o metodo do LINQ Select
             */
            return _context.Employees.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select( x =>
                 new EmployeeDTO()
                 {
                     Id = x.id,             //[8] observe que pegamos o dado retorndo
                     NameEmployee = x.name, // da request que esta em x = id, name e photo
                     Photo = x.photo,       // e jogamos no DTO = Id, NameEmployee e Photo 
                 }
                )
                .ToList();

        }
    }
}

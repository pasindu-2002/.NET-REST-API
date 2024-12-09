using first_app.Data;
using first_app.Models;

namespace first_app.Services.impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }


        //Fetch All Employees
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }

        //Fetch Employee By ID
        public IEnumerable<Employee> GetEmployeeById(int id)
        {
            return _context.Employees.Where(e => e.id == id);
        }

        //Add new Employee
        public  IEnumerable<Employee> AddEmployee(Employee employee) 
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return _context.Employees;
        }


        //Remove Employee By Id
        public IEnumerable<Employee> DeleteEmployee(int id)
        {
            var emp = _context.Employees.Find(id);

            if (emp == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }

            _context.Employees.Remove(emp);
            _context.SaveChanges();

            return _context.Employees.ToList();
        }

        //Update Employee
        public IEnumerable<Employee> UpdateEmloyee(int employeeId, Employee employee)
        {
            var existingEmp = _context.Employees.Find(employeeId);

            if (existingEmp == null)
            {
                throw new KeyNotFoundException($"Employee with ID {employeeId} not found.");
            }

            existingEmp.name = employee.name;

            existingEmp.position = employee.position;

            existingEmp.salary = employee.salary;

            _context.SaveChanges();

            return _context.Employees.Where(e => e.id == employeeId);
        }

    }
}

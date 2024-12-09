using System.Linq;
using first_app.Data;
using first_app.Models;

namespace first_app.Services
{
    public interface IEmployeeService
    {
        //Fetch All Employees interface
        public IEnumerable<Employee> GetAllEmployees();

        //Fetch Employee By ID interface
        public IEnumerable<Employee> GetEmployeeById(int id);

        //Add new Employee interface
        public IEnumerable<Employee> AddEmployee(Employee  employee);

        //Remove Employee interface
        public IEnumerable<Employee> DeleteEmployee(int employeeId);

        //Update Employee interface
        public IEnumerable<Employee> UpdateEmloyee(int employeeId, Employee employee);
    }
}

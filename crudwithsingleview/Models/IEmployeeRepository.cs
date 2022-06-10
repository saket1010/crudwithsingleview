namespace crudwithsingleview.Models
{
    public interface IEmployeeRepository
    {
        public void AddOrUpdateEmployee(Employee employee);
        public List<Employee> GetEmployees();
        public Employee GetEmployeeById(int id);
        public Employee GetEmployeeByName(string name);
        public void DeleteEmployee(int id);
        
    }
}

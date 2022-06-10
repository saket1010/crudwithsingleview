namespace crudwithsingleview.Models
{
    public class EmployeeRepository:IEmployeeRepository
    {
        static List<Employee> _employees=new List<Employee>();

        public void AddOrUpdateEmployee(Employee employee)
        {
            if(employee==null)
            {
                throw new Exception("null parameter passed");
            }
            else
            {
                if (GetEmployeeById(employee.Id)==null)
                {
                    _employees.Add(employee);
                }
                else
                {
                    foreach (Employee emp in _employees)
                    {
                        if (emp.Id == employee.Id)
                        {
                            emp.Name = employee.Name;
                            emp.Address = employee.Address;
                            emp.Age = employee.Age;
                            emp.JoiningDate = employee.JoiningDate;
                            emp.Designation = employee.Designation;
                            emp.Salary= employee.Salary;
                        }
                    }
                }
            }
        }

        public void DeleteEmployee(int id)
        {
            if(!_employees.Remove(GetEmployeeById(id)))
            {
                throw new Exception("Invalid Employee");
            }
        }

        public Employee GetEmployeeById(int id)
        {
            foreach(Employee e in _employees)
            {
                if(e.Id == id)
                {
                    return e;
                }
            }
            return null;
             
        }

        public Employee GetEmployeeByName(string name)
        {
            foreach (Employee e in _employees)
            {
                if (e.Name == name)
                {
                    return e;
                }
            }
            return null;
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}

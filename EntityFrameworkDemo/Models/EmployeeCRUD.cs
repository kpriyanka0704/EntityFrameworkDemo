namespace EntityFrameworkDemo.Models
{
    public class EmployeeCRUD
    {
        private readonly ApplicationDbContext db;
        public EmployeeCRUD(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            //var result = from p in db.Products
            //             select p;
            //return result;
            return db.Employees.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            //var result = from p in db.Products
            //             where p.Id == id
            //             select p;
            // OR

            var result = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }
        public int AddEmployee(Employee employee)
        {
            int result = 0;
            db.Employees.Add(employee); // add product object in the DbSet
            result = db.SaveChanges(); // reflect the changes from DbSet to DB
            return result;
        }
        public int EditEmployee(Employee employee) // new data
        {
            int result = 0;
            var emp = db.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (emp != null) // prod contains old data
            {
                emp.Name = employee.Name;
                emp.City = employee.City;
                emp.Salary = emp.Salary;
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            var emp = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (emp != null) // prod contains old data
            {
                db.Employees.Remove(emp);
                result = db.SaveChanges();
            }
            return result;

        }
    }
}

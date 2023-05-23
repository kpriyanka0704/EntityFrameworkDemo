namespace EntityFrameworkDemo.Models
{
    public class StudentCRUD
    {
        private readonly ApplicationDbContext db;
        public StudentCRUD(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Student> GetStudents()
        {
            //var result = from s in db.Students
            //             select s;
            //return result;
            return db.Students.ToList();
        }
        public Student GetStudentById(int id)
        {
            //var result = from p in db.Products
            //             where p.Id == id
            //             select p;
           
            //OR

            var result = db.Students.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }
        public int AddStudent(Student student)
        {
            int result = 0;
            db.Students.Add(student);
            result = db.SaveChanges(); 
            return result;
        }
        public int EditStudent(Student student) 
        {
            int result = 0;
            var stu = db.Students.Where(x => x.Id == student.Id).FirstOrDefault();
            if (stu != null)
            {
                stu.Name = student.Name;
                stu.Branch = student.Branch;
                stu.Percentage = student.Percentage;
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            var stu = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (stu != null)
            {
                db.Students.Remove(stu);
                result = db.SaveChanges();
            }
            return result;

        }
    }
}

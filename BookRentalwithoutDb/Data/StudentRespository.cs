using BookRentalwithDb.Models;

namespace BookRentalwithDb.Data;

public class StudentRespository
{
    private static List<Student> data = new List<Student>
    {
      new Student{Id=1, Name = "Çağla", Surname = "Ecrin", BirthDate = new DateTime(2001, 05, 25)},
      new Student{Id=2, Name = "Kıvanç", Surname = "Emir", BirthDate = new DateTime(2011, 04, 12)},
      new Student{Id=3, Name = "Yeşim", Surname = "Baybüyük", BirthDate = new DateTime(1981, 05, 23)},
      new Student{Id=4, Name = "Ercan", Surname = "Baybüyük", BirthDate = new DateTime(1972, 03, 13)},
      new Student{Id=5, Name = "Bal", Surname = "Tilki", BirthDate = new DateTime(2020, 09, 20)},
      new Student{Id=6, Name = "Tako", Surname = "Tuka", BirthDate = new DateTime(2022, 03, 13)},

    };    
        
        
    public List<Student> GetAllStudents()
    {
       return data;  // "select * from students;
    }
    
    public Student GetStudent(int id)
    {
        Student result = data.Where(s => s.Id == id).FirstOrDefault();
        // select * from students where ID=1;
        
        return result;
    }
    
    public void Delete(int id)
    {
        var student = GetAllStudents().FirstOrDefault(s => s.Id == id);
        data.Remove(student);
        if (student != null)
        {
            GetAllStudents().Remove(student);
        }
    }
   // data.RemoveAll(d => d.Id == id);
    public void Insert(Student student)
    {
        data.Add(student);
    }
    
    public void Update(Student student)
    {
        var studentInDb = data.Where(s => s.Id == student.Id).FirstOrDefault();

        if (studentInDb != null)
        {
            studentInDb.Name = student.Name;
            studentInDb.Surname = student.Surname;
            studentInDb.BirthDate = student.BirthDate; 
        }     
        
            
    }
    
   

}


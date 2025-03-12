using BookRentalwithDb.Data;
using BookRentalwithDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalwithDb.Controllers;

public class StudentController : Controller
{
    // GET
    public IActionResult Index() //tüm öğrencileri gösterme sayfası
    {
        StudentRespository repository = new StudentRespository();

        var students = repository.GetAllStudents();
        return View(students);
    }


    public IActionResult Detail(int id) //öğrenci sayfası için detail kısmı
    {
        StudentRespository repository = new StudentRespository();
        var student = repository.GetStudent(id);
        if (student == null)
        {
            return NotFound();
        }
        else
        {
            return View(student);
        }

    }

    public IActionResult Create() //yeni veri eklemek için.
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student) //veriyi kaydetmek için.submit edileni çalıştırır.
    {
        StudentRespository respository = new StudentRespository();
        respository.Insert(student);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        StudentRespository respository = new StudentRespository();
        var student = respository.GetStudent(id);

        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        StudentRespository respository = new StudentRespository();
        var student = respository.GetStudent(id);
        respository.Delete(id);
        
        if (student == null)
        {
            return NotFound();
        }
        
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        StudentRespository respository = new StudentRespository();
        var student = respository.GetStudent(id);

        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            StudentRespository respository = new StudentRespository();
            respository.Update(student);
            return RedirectToAction("Index");
        }
        return View(student);
    }
}



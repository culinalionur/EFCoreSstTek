using EFCoreTutorialData.Context;
using EFCoreTutorialData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public ApplicationDbContext _applicationDbContext;

        public StudentController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var students = await _applicationDbContext.Students.ToListAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            StudentAddress newAddress = new StudentAddress()
            {
                City = "İstanbul",
                District = "Kadıköy",
                Country = "Turkey",
                FullAddress = "xx yy"
            };
            await _applicationDbContext.StudentAddresses.AddAsync(newAddress);
            await _applicationDbContext.SaveChangesAsync();
            Student newStudent = new Student()
            {
                FirstName = "Onur",
                LastName = "Akıncı",
                Number = 1,
                AddressId = newAddress.Id
            };
            await _applicationDbContext.AddAsync(newStudent);
            await _applicationDbContext.SaveChangesAsync();

            return Ok();

        }
    }
}

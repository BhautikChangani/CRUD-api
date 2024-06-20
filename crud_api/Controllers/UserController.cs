using crud_api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using crud_api.ViewModels;


namespace crud_api.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    [EnableCors("AllowAll")]
    public class UserController : Controller
    {
        private readonly BhautikchanganiDbContext _context;
        public UserController() { 
        _context = new BhautikchanganiDbContext();
        }
        
        [HttpGet(Name = "Getemployee")]
        public List<employeevm> GetUsers()
        {
            List<employeevm> data = new List<employeevm>();
            var listofData = _context.Employee1s.ToList();
            foreach (var item in listofData)
            {
                data.Add(new()
                {
                    EmpId = item.EmpId,
                    DeptId = item.DeptId,
                    MngrId = item.MngrId,
                    EmpName = item.EmpName,
                    Salary = item.Salary,
                });
            }
            return data;
        }
        [HttpGet]
        public ActionResult GetUser(int id)
        {
            var data = _context.Employee1s.FirstOrDefault(x => x.EmpId == id);
            return Json(data);
        }
        [HttpPost(Name = "UpdateEmployee")]
        public async Task UpdateUsersData([FromBody] Employee1 employee)
        {


            Employee1 employee1 = _context.Employee1s.FirstOrDefault(x => x.EmpId == employee.EmpId);
            employee1.DeptId = employee.DeptId;
            employee1.MngrId = employee.MngrId;
            employee1.EmpName = employee.EmpName;
            employee1.Salary = employee.Salary;
            _context.Employee1s.Update(employee1);
            _context.SaveChanges();
        }
        [HttpPost]
        public void CreateUser([FromBody] Employee1 employee)
        {
            var listofData = _context.Employee1s.ToList();
            var data = _context.Employee1s.OrderBy(x => x.EmpId).LastOrDefault();
            int id = data.EmpId.Value+1;
            Employee1 newEmployee = new Employee1()
            {   EmpId = id,
                DeptId = employee.DeptId,
                MngrId = employee.MngrId,
                EmpName = employee.EmpName,
                Salary = employee.Salary,
            };
            _context.Employee1s.Add(newEmployee);
            _context.SaveChanges();
        }
        
        [HttpPost(Name ="DeleteEmployee")]
        public void DeleteUser([FromBody] Employee1 employee)
        {
           /* Employee1 employee1 = _context.Employee1s.FirstOrDefault(x => x.EmpId == employee.EmpId);*/
            _context.Remove(employee);
            _context.SaveChanges();
        }
        public List<Department1> GetDepartmentList()
        {
            return _context.Department1s.ToList();
        }

    }
   

}

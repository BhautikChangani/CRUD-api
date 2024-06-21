using crud_api.Models;
using crud_api.DBContext;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using crud_api.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace crud_api.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    [EnableCors("AllowAll")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController() { 
        _context = new ApplicationDbContext();
        }
        
        [HttpGet(Name = "Getemployee")]
        public List<employeevm> GetUsers()
        {
            List<employeevm> data = new List<employeevm>();
            var listofData = _context.Employee1s.Include(x => x.Dept).Include(x => x.Mngr).ToList();
           
            foreach (var item in listofData)
            {
                data.Add(new()
                {
                    EmpId = item.EmpId,
                    DeptId = item.DeptId,
                    MngrId = item.MngrId,
                    EmpName = item.EmpName,
                    Salary = item.Salary,
                    DeptName = item.Dept?.DeptName,
                    MngrName = item.Mngr?.MngrName
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
        public async Task UpdateUsersData([FromBody] employeevm employee)
        {
            Department1 department = _context.Department1s.FirstOrDefault(x => x.DeptName == employee.DeptName);
            Manager1 manager = _context.Manager1s.FirstOrDefault(x => x.MngrName == employee.MngrName);
            Employee1 employee1 = _context.Employee1s.FirstOrDefault(x => x.EmpId == employee.EmpId);
            employee1.DeptId = department.DeptId;
            employee1.MngrId = manager.MngrId;
            employee1.EmpName = employee.EmpName;
            employee1.Salary = employee.Salary;
            _context.Employee1s.Update(employee1);
            _context.SaveChanges();
        }
        [HttpPost]
        public void CreateUser([FromBody] employeevm employee)
        {
            Department1 department = _context.Department1s.FirstOrDefault(x => x.DeptName == employee.DeptName);
            Manager1 manager = _context.Manager1s.FirstOrDefault(x => x.MngrName == employee.MngrName);
            var listofData = _context.Employee1s.ToList();
            var data = _context.Employee1s.OrderBy(x => x.EmpId).LastOrDefault();
            int id = data.EmpId+1;
            Employee1 newEmployee = new Employee1()
            {   EmpId = id,
                DeptId = department.DeptId,
                MngrId = manager.MngrId,
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
        [HttpGet]
        public List<Department1> GetDepartmentList()
        {
            return _context.Department1s.ToList();
        }
        [HttpGet]
        public List<Manager1> GetManagerList()
        {
            return _context.Manager1s.ToList();
        }

    }
   

}

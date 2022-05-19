using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UkrainianHouse.Data;
using UkrainianHouse.Models;

namespace UkrainianHouse.Controllers
{
    public class TaskController : Controller
    {

        private readonly ConstructionCompany2Context _context;

        public TaskController(ConstructionCompany2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Employee> employees = _context.Employees.ToList();
            List<Models.Task> tasks = _context.Tasks.ToList();
            List<Status> statuses = _context.Statuses.ToList();

            var multipletable = from e in employees
                                join tas in tasks on e.EmployeeId equals tas.EmployeeId into table1
                                from tas in table1.DefaultIfEmpty()
                                join st in statuses on tas.StatusId equals st.StatusId into table2
                                from st in table2.DefaultIfEmpty()
                                select new EmployeeTask { employeedetails = e, taskdetails = tas, statusdetails = st };

            return View(multipletable);
        }
       
    }
}

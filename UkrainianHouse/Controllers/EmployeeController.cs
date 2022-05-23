using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UkrainianHouse.Data;
using UkrainianHouse.Models;

namespace UkrainianHouse.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ConstructionCompany2Context _context;

        public EmployeeController(ConstructionCompany2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Project> projects = _context.Projects.ToList();

            List<Employee> employees = _context.Employees.ToList();

            List<BridgeEmployeeProject> bridgeEmployeeProjects = _context.BridgeEmployeeProjects.ToList();

            var multipletable = from bridge in bridgeEmployeeProjects
                                join p in projects on bridge.ProjectId equals p.ProjectId into table1
                                from p in table1.DefaultIfEmpty()

                                join e in employees on bridge.EmployeeId equals e.EmployeeId into table2
                                from e in table2.DefaultIfEmpty()
                                select new EmployeeProject { projectdetails = p,employeedetails = e,bridgeEmployeedetails = bridge };


            return View(multipletable);
        }

        public IActionResult Details(int? id)
        {
            List<Project> projects = _context.Projects.ToList();

            List<Employee> employees = _context.Employees.ToList();

            List<BridgeEmployeeProject> bridgeEmployeeProjects = _context.BridgeEmployeeProjects.ToList();

            var multipletable = from bridge in bridgeEmployeeProjects
                                join p in projects on bridge.ProjectId equals p.ProjectId into table1
                                from p in table1.DefaultIfEmpty()

                                join e in employees on bridge.EmployeeId equals e.EmployeeId into table2
                                from e in table2.DefaultIfEmpty()
                                where bridge.EmployeeProjectId == id
                                select new EmployeeProject { projectdetails = p, employeedetails = e, bridgeEmployeedetails = bridge };


            return View(multipletable);
        }
    }
}

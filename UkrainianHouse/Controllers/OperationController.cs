using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UkrainianHouse.Data;
using UkrainianHouse.Models;

namespace UkrainianHouse.Controllers
{
    public class OperationController : Controller
    {
        private readonly ConstructionCompany2Context _context;

        public OperationController(ConstructionCompany2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Project> projects = _context.Projects.ToList();

            List<Operation> operations = _context.Operations.ToList();

            List<Material> materials = _context.Materials.ToList();

            List<Date> dates = _context.Dates.ToList();

            var multipletables = from oper in operations
                                 join mat in materials on oper.MaterialId equals mat.MaterialId into table1
                                 from mat in table1.DefaultIfEmpty()

                                 join dat in dates on oper.DateId equals dat.DateId into table2
                                 from dat in table2.DefaultIfEmpty()

                                 join p in projects on oper.ProjectId equals p.ProjectId into table3
                                 from p in table3.DefaultIfEmpty()
                                 select new MaterialOperations { projectdetails = p, operationdetails = oper, datedetails = dat, materialdetails = mat };

            return View(multipletables);
        }
    }
}

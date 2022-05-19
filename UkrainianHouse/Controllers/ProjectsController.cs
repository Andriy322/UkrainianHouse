using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UkrainianHouse.Data;
using UkrainianHouse.Models;

namespace UkrainianHouse.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ConstructionCompany2Context _context;

        public ProjectsController(ConstructionCompany2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Project> projects = _context.Projects.ToList();
            List<Location> locations = _context.Locations.ToList();

            var multipletable = from p in projects
                                join loc in locations on p.LocationId equals loc.LocationId into table1
                                from loc in table1.DefaultIfEmpty()
                                select new ProjectLocation { projectsdetails = p, locationsdetails = loc };


            return View(multipletable);
        }
    }
}

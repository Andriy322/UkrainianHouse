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

        public IActionResult Details(int ? id)
        {
            List<Project> projects = _context.Projects.ToList();
            List<Location> locations = _context.Locations.ToList();

            var multipletable = from p in projects
                                join loc in locations on p.LocationId equals loc.LocationId into table1
                                from loc in table1.DefaultIfEmpty()
                                where p.ProjectId == id
                                select new ProjectLocation { projectsdetails = p, locationsdetails = loc };

            return View(multipletable);
        } 

      
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project model)
        {
            Project newproject = new Project();
            newproject.ProjectName = model.ProjectName;
            newproject.ProjectStatus = model.ProjectStatus;
            newproject.LocationId = model.LocationId;

            _context.Projects.Add(newproject);
            _context.SaveChanges();

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int ? id)
        {
            var item = _context.Projects.Find(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Project model)
        {
            var item = _context.Projects.Where(x => x.ProjectId == model.ProjectId).First();
            item.ProjectName = model.ProjectName;
            item.ProjectStatus = model.ProjectStatus;
            item.LocationId = model.LocationId;

            _context.SaveChanges();
            return View();
        }




        public IActionResult Delete(int ? id)
        {
            var item = _context.Projects.Where(x => x.ProjectId == id).First();

            _context.Projects.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}

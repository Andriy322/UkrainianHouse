using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UkrainianHouse.Data;
using UkrainianHouse.Models;

namespace UkrainianHouse.Controllers
{
    public class StorageController : Controller
    {
        private readonly ConstructionCompany2Context _context;

        public StorageController(ConstructionCompany2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Storage> storageobj = _context.Storages.ToList();
            List<Material> materials = _context.Materials.ToList();

            var multipletable = from st in storageobj
                                join mat in materials on st.MaterialId equals mat.MaterialId into table1
                                from mat in table1.DefaultIfEmpty()
                                select new StorageMaterial { storagedetails = st, materialdetails = mat };
                   
            return View(multipletable);
        }

        public IActionResult Details(int? id)
        {
            List<Storage> storageobj = _context.Storages.ToList();
            List<Material> materials = _context.Materials.ToList();

            var multipletable = from st in storageobj
                                join mat in materials on st.MaterialId equals mat.MaterialId into table1
                                from mat in table1.DefaultIfEmpty()
                                where st.StorageId == id
                                select new StorageMaterial { storagedetails = st, materialdetails = mat };


            return View(multipletable);
        }
    }
}

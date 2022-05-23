using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UkrainianHouse.Data;
using UkrainianHouse.Models;

namespace UkrainianHouse.Controllers
{
    public class AccountingController : Controller
    {
        private readonly ConstructionCompany2Context _context;

        public AccountingController(ConstructionCompany2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Accounting> accountings = _context.Accountings.ToList();
            List<Employee> employees = _context.Employees.ToList();
            List<Date> dates = _context.Dates.ToList();

            var multipletable = from a in accountings
                                join e in employees on a.EmployeeId equals e.EmployeeId into table1
                                from e in table1.DefaultIfEmpty()
                                join d in dates on a.DateId equals d.DateId into table2
                                from d in table2.DefaultIfEmpty()
                                select new AccountingEmployee { accountingdetails = a, employeedetails = e, datedetails = d };


            return View(multipletable);
        }

        public IActionResult Details(int? id)
        {
            List<Accounting> accountings = _context.Accountings.ToList();
            List<Employee> employees = _context.Employees.ToList();
            List<Date> dates = _context.Dates.ToList();

            var multipletable = from a in accountings
                                join e in employees on a.EmployeeId equals e.EmployeeId into table1
                                from e in table1.DefaultIfEmpty()
                                join d in dates on a.DateId equals d.DateId into table2
                                from d in table2.DefaultIfEmpty()
                                where a.TransactionId == id
                                select new AccountingEmployee { accountingdetails = a, employeedetails = e, datedetails = d };

            return View(multipletable);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using SaveTimeCore.Interfaces;
using SaveTimeCore.Models;
using SaveTimeCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SaveTimeCore.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly IRepository<Company> _repository;
        IMapper _mapper;

        public CompanyController(IRepository<Company> repository)
        {
            _repository = repository;
            var config = new MapperConfiguration(
                c => {
                    c.CreateMap<Employee, EmployeeDetailsViewModel>();
                    c.CreateMap<Branch, BranchDetailsViewModel>();
                    c.CreateMap<Company, CompanyDetailsViewModel>();
                });
            _mapper = config.CreateMapper();
        }

        public IActionResult Index()
        {
            IEnumerable<Company> companies = _repository.GetAll();
            var company = new CompanyViewModel();
            foreach(var com in companies)
            {
                var cvm = _mapper.Map<CompanyDetailsViewModel>(com);
                company.Companies.Add(cvm);
            }
            return View(company);
        }

        public IActionResult Details(int id)
        {
            Company company = _repository.GetById(id);
            if (company == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }

            var companyDetails = _mapper.Map<CompanyDetailsViewModel>(company);
            //CompanyDetailsViewModel companyDetails = new CompanyDetailsViewModel()
            //{
            //    Id = company.Id,
            //    Name = company.Name,
            //    City = company.City,
            //};
            IList<BranchDetailsViewModel> branchDetails = new List<BranchDetailsViewModel>();

            foreach(var branch in company.Branches)
            {
                var branchDetail = _mapper.Map<BranchDetailsViewModel>(branch);
                //BranchDetailsViewModel branchDetail = new BranchDetailsViewModel()
                //{
                //    Id = branch.Id,
                //    Adress = branch.Adress,
                //    Email = branch.Email,
                //    Phone = branch.Phone,
                //    StartWork = branch.StartWork,
                //    EndWork = branch.EndWork,
                //    StepWork = branch.StepWork,
                //};

                IList<EmployeeDetailsViewModel> employeesDetails = new List<EmployeeDetailsViewModel>();

                foreach (var employee in branch.Employees)
                {
                    var employeeDetail = _mapper.Map<EmployeeDetailsViewModel>(employee);
                    //EmployeeDetailsViewModel employeeDetail = new EmployeeDetailsViewModel
                    //{
                    //    Id = employee.Id,
                    //    Name = employee.Name
                    //};

                    employeesDetails.Add(employeeDetail);
                }
                branchDetail.Employees = employeesDetails;
                branchDetails.Add(branchDetail);

            }

            companyDetails.Branches = branchDetails;
            return View(companyDetails);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company company)
        {
            if ((ModelState.IsValid))
            {
                _repository.Create(company);
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult CreatePartial()
        {
            return PartialView("_CreateCompany");
        }

        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }
            Company company = _repository.GetById(id);
            if (company == null)
            {
                //return HttpNotFound();
                return NotFound("Ресурс в приложении не найден");
            }
            return View(company);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(company);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }

            Company company = _repository.GetById(id);
            if (company == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }

            return View(company);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Company company = _repository.GetByIdInclude(id, "Branches");
            _repository.Remove(company);
            return RedirectToAction("Index");
        }

        public JsonResult GetCompaniesList()
        {
            IList<CompanySelect> cs = new List<CompanySelect>();
            IEnumerable<Company> cl = _repository.GetAll().ToList();
            foreach (var item in cl)
            {
                cs.Add(new CompanySelect { Id = item.Id, Name = item.Name });
            }
            return Json(cs);
        }

    }

    public class Info
    {
        public string Message { get; set; }
        public Company Company { get; set; }
    }
    public class CompanySelect
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
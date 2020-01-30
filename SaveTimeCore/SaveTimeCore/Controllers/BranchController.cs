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
    public class BranchController : BaseController
    {
        private readonly IRepository<Branch> _repository;
        IMapper _mapper;

        public BranchController(IRepository<Branch> repository)
        {
            _repository = repository;
            var config = new MapperConfiguration(
                    c => {
                        c.CreateMap<BranchEditModel, Branch>();
                        c.CreateMap<Branch, BranchViewModel>();
                        c.CreateMap<Branch, BranchEditModel>();
                    });
            _mapper = config.CreateMapper();
        }

        public IActionResult Index()
        {
            IEnumerable<Branch> branchs = _repository.GetAll();
            IList<BranchViewModel> viewBranchs = new List<BranchViewModel>();
            foreach (var brn in branchs)
            {
                BranchViewModel avm = _mapper.Map<BranchViewModel>(brn);
                if (brn.CompanyId != null)
                {
                    avm.CompanyName = brn.Company.Name;
                }
                else
                {
                    avm.CompanyName = "";
                }
                viewBranchs.Add(avm);
            }
            return View(viewBranchs);
        }
        public IActionResult Create()
        {
            BranchEditModel bem = new BranchEditModel();

            return View(bem);

        }
        [HttpPost]
        public IActionResult Create(BranchEditModel bem)
        {
            if (ModelState.IsValid)
            {
                Branch branch = _mapper.Map<Branch>(bem);
                _repository.Create(branch);
                return Content("Данные добавлены");
            }

          return View();

        }

        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }
            Branch branch = _repository.GetById(id);
            if (branch == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }
            BranchEditModel bem = _mapper.Map<BranchEditModel>(branch);

            IRepository<Company> _repoCompany;
            _repoCompany = kernel.Get<IRepository<Company>>();
            bem.Companies = _repoCompany.GetAll().ToList();

            return View(bem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BranchEditModel bem)
        {
            if (ModelState.IsValid)
            {
                Branch branch = _mapper.Map<Branch>(bem);
                _repository.Edit(branch);
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

            Branch branch = _repository.GetById(id);
            if (branch == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }
            BranchEditModel bem = _mapper.Map<BranchEditModel>(branch);

            IRepository<Company> _repoCompany;
            _repoCompany = kernel.Get<IRepository<Company>>();
            bem.Companies = _repoCompany.GetAll().ToList();

            return View(bem);
   
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // GetByIdInclude(id, "Employees")
            // нужно чтобы при каскадном удалении 
            // записей из Branch 
            // связанные Branches.Id = Employees.BranchId
            // данные из Employee не удалялись,
            // Employees.BranchId присваиваося null
            Branch branch = _repository.GetByIdInclude(id, "Employees");
            _repository.Remove(branch);
            return RedirectToAction("Index");
        }

    }
}
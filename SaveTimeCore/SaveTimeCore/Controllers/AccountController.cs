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
    public class AccountController : BaseController
    {
        // GET: Account
        private readonly IRepository<Account> _repository;
        IMapper _mapper;

        public AccountController(IRepository<Account> repository)
        {
            _repository = repository;
            var config = new MapperConfiguration(
                c => {
                    c.CreateMap<Account, AccountViewModel>();
                    c.CreateMap<AccountViewModel, Account>();
                });
            _mapper = config.CreateMapper();
        }

        public IActionResult Index()
        {
            IEnumerable<Account> accounts = _repository.GetAll();

            IList<AccountViewModel> viewAccounts = new List<AccountViewModel>();
            foreach (var acc in accounts)
            {
                AccountViewModel avm = _mapper.Map<AccountViewModel>(acc);
                viewAccounts.Add(avm);
            }
            return View(viewAccounts);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AccountViewModel avm)
        {
            if (ModelState.IsValid)
            {
                Account account = _mapper.Map<Account>(avm);
                _repository.Create(account);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }
            Account account = _repository.GetById(id);
            if (account == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }
            AccountViewModel avm = _mapper.Map<AccountViewModel>(account);

            return View(avm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AccountViewModel avm)
        {
            if (ModelState.IsValid)
            {
                Account account = _mapper.Map< Account> (avm);
                _repository.Edit(account);
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

            Account account = _repository.GetById(id);
            if (account == null)
            {
                return NotFound("Ресурс в приложении не найден");
            }
            AccountViewModel avm = _mapper.Map<AccountViewModel>(account);

            return View(avm);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // "GetByIdInclude(id, "Employees")"
            // нужно чтобы при чтобы при каскадном удалении 
            // записей из Account 
            // связанные Accounts.Id = Employees.AccountId
            // данные из Employee не удалялись,
            // Employees.AccountId присваиваося null
            Account account = _repository.GetByIdInclude(id, "Employees");
            _repository.Remove(account);
            return RedirectToAction("Index");
        }

    }
}
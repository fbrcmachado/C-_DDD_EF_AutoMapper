using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClienteController : Controller
    {

        private readonly IClienteAppService _clienteApp;

        public ClienteController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }


        // GET: Cliente
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());
            return View(clienteViewModel);
        }

        // GET: Cliente/Details/5
        public ActionResult Especiais()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.ObterClientesEspeciais());
            return View(clienteViewModel);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
 
        }

        [HttpGet]
        public ActionResult Create()
        {
            var clienteViewModel = new ClienteViewModel();
            return View(clienteViewModel);
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid) 
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente >(cliente);
                _clienteApp.Update(clienteDomain);

                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _clienteApp.GetById(id);
            _clienteApp.Remove(cliente);

            return RedirectToAction("Index");
        }
    }
}

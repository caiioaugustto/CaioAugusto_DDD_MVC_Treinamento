using System;
using System.Net;
using System.Web.Mvc;
using CaioAugusto.DDDMVCTreinamento.App.ViewModels;
using CaioAugusto.DDDMVCTreinamento.App.Services;
using CaioAugusto.DDDMVCTreinamento.App.Interfaces;
using CaioAugusto.DDDMVCTreinamento.UI.Site.Filters;

namespace CaioAugusto.DDDMVCTreinamento.UI.Site.Controllers
{
    //ModuloCliente (Claims/Permissões) - AD, ED, LT, VI, EX

    [Authorize]
    [RoutePrefix("modulo-administrativo")]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController()
        {
            _clienteAppService = new ClienteAppService();
        }

        //[ClaimsAuthorize("ModuloCliente", "LT")]
        [Route("listar-clientes")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        //[ClaimsAuthorize("ModuloCliente", "VI")]
        [Route("{id:guid}/detalhe-cliente")]
        public ActionResult Details(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        //[ClaimsAuthorize("ModuloCliente", "AD")]
        [Route("novo-cliente")]
        public ActionResult Create()
        {
            return View();
        }

        //[ClaimsAuthorize("ModuloCliente", "AD")]
        [Route("novo-cliente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Adicionar(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        //[ClaimsAuthorize("ModuloCliente", "ED")]
        [Route("{id:guid}/editar-cliente")]
        public ActionResult Edit(Guid? id, string str)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        //[ClaimsAuthorize("ModuloCliente", "ED")]
        [Route("{id:guid}/editar-cliente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        //[ClaimsAuthorize("ModuloCliente", "EX")]
        [Route("{id:guid}/excluir-cliente")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        //[ClaimsAuthorize("ModuloCliente", "EX")]
        [Route("{id:guid}/excluir-cliente")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

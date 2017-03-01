using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaioAugusto.DDDMVCTreinamento.UI.Site.Filters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        //OnActionExecuted é quando já aconteceu o erro.
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //FilterContext consegue pegar todaas as informações do erro, ip da máquina, camada que deu erro, controller, usuário e etc

            if (filterContext.Exception != null)
            {
                //Registre o filtro na FilterConfig
                // Manipular a EX
                // Injetar alguma LIB de tratamento de erro
                //  -> Gravar log do erro no BD
                //  -> Email para o admin
                //  -> Retornar cod de erro amigavel

                // SEMPRE DE FORMA ASYNC

                //FilterContext = true, fala para o seu iis que você tratou a exceção

                //Adicione o seu filtro no filter de appStart
                filterContext.ExceptionHandled = true;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
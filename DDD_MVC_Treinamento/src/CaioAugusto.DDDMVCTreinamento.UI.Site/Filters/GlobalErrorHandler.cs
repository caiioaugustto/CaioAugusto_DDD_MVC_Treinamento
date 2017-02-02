using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaioAugusto.DDDMVCTreinamento.UI.Site.Filters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(filterContext.Exception != null)
            {
                //Registre o filtro na FilterConfig
                // Manipular a EX
                // Injetar alguma LIB de tratamento de erro
                //  -> Gravar log do erro no BD
                //  -> Email para o admin
                //  -> Retornar cod de erro amigavel

                // SEMPRE DE FORMA ASYNC

                filterContext.ExceptionHandled = true;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
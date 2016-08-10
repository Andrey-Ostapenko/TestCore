using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        /// <summary>
        ///     выполняется при вызове метода контроллера до его непосредственного выполнения.
        /// </summary>
        /// <param name="context"></param>
        [NonAction]
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        /// <summary>
        ///     выполняется после выполнения метода контроллера.
        /// </summary>
        /// <param name="context"></param>
        [NonAction]
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        /// <summary>
        ///     представляет асинхронную версию метода OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        [NonAction]
        public override async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            OnActionExecuting(context);
            if (context.Result == null)
            {
                OnActionExecuted(await next());
            }
        }
    }
}
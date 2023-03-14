using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter//action a gelen isteklerde devreye girer
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)//gelen isteklerin hatalarını bulma
            {
                var errors = context.ModelState
                     .Where(x => x.Value.Errors.Any())
                     .ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage)).ToArray();//key le gelen eror numarasına karşılık gelen eror mesajlarını getirir
                context.Result = new BadRequestObjectResult(errors);
            }
            await next();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace nbaDemo.API.Filters
{
    public class CheckExistingEntity<T> : IAsyncActionFilter
    {
        private readonly T service;

        public CheckExistingEntity(T service)
        {
            this.service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idExist = context.ActionArguments.ContainsKey("id");

            if (!idExist)
            {
                context.Result = new BadRequestObjectResult(new { message = $"There is no id parameter." });
            }
            else
            {
                var id = (int)context.ActionArguments["id"];
                var serviceType = service.GetType();
                var isExistMethod = serviceType.GetMethod("IsExist");
                var isExistTask = (Task<bool>)isExistMethod.Invoke(service, new object[] { id });
                bool result = await isExistTask;

                if (result)
                {
                    await next.Invoke();
                }

                context.Result = new BadRequestObjectResult(new { message = $"The {serviceType.Name} could not find the entity with the id of {id}." });
            }
        }
    }
}

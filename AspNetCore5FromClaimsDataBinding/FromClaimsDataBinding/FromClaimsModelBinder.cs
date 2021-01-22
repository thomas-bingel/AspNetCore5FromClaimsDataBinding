using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore5FromClaimsDataBinding.FromClaimsDataBinding
{
    public class FromClaimsModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var name = bindingContext.FieldName;
            var valueString = bindingContext.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == name)?.Value;
            if (bindingContext.ModelType == typeof(Guid))
            {
                if (Guid.TryParse(valueString, out Guid guid))
                {
                    bindingContext.Result = ModelBindingResult.Success(guid);
                }
                else
                {
                    bindingContext.ModelState.AddModelError(name, $"cannot get {name} from Claims. Not a valid GUID.");
                }
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Success(valueString);
            }
            return Task.CompletedTask;
        }
    }
}

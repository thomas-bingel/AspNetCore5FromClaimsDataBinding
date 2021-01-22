using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace AspNetCore5FromClaimsDataBinding.FromClaimsDataBinding
{
    public class FromClaimsDataBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }

            if (context.BindingInfo?.BindingSource == FromClaimsBindingSource.Claims)
            {
                return new BinderTypeModelBinder(typeof(FromClaimsModelBinder));
            }
            return null;
        }
    }
}

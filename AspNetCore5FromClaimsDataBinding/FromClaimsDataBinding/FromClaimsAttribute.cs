using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace AspNetCore5FromClaimsDataBinding.FromClaimsDataBinding
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class FromClaimsAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider
    {
        public string Name { get; set; }

        public FromClaimsAttribute() : base()
        {
        }

        public FromClaimsAttribute(string name) : this()
        {
            this.Name = name;
        }

        public BindingSource BindingSource => FromClaimsBindingSource.Claims;

    }
}

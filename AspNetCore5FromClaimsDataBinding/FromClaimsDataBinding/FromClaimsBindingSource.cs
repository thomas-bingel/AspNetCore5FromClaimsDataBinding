using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCore5FromClaimsDataBinding.FromClaimsDataBinding
{
    public class FromClaimsBindingSource : BindingSource
    {
        public static readonly BindingSource Claims = new FromClaimsBindingSource(
          "FromClaims",
          "FromClaims",
          true,
          true
      );

        public FromClaimsBindingSource(string id, string displayName, bool isGreedy, bool isFromRequest) 
            : base(id, displayName, isGreedy, isFromRequest)
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using ModelBinding.Models;

namespace ModelBinding.CusomModelBinders
{
    public class PersonModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if(context.Metadata.ModelType == typeof(User))
            {
                return new BinderTypeModelBinder(typeof(PersonModelBinder));
            }

            return null;
        }
    }
}

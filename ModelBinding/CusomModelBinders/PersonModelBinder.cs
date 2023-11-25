using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBinding.Models;

namespace ModelBinding.CusomModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        User usr = new User();
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            usr.Email = bindingContext.ValueProvider.GetValue("Email").FirstValue;
            usr.Email += " " + "is the user's email";

            bindingContext.Result = ModelBindingResult.Success(usr);
            return Task.CompletedTask;
        }
    }
}

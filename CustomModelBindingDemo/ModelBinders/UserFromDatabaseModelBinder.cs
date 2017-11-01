using CustomModelBindingDemo.Data;
using System.Web.Mvc;

namespace CustomModelBindingDemo.ModelBinders
{
    public class UserFromDatabaseModelBinder : IModelBinder
    {
        private readonly UserRepository _userRepository = new UserRepositoryDictionary();

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;

            return _userRepository.Retrieve(value);
        }
    }
}
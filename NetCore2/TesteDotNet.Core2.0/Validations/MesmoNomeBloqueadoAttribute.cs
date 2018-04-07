using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using TesteDotNet.Core2_0.Models;
using TesteDotNet.Core2_0.Services.Base;

namespace TesteDotNet.Core2_0.Validations
{
    public class MesmoNomeBloqueadoAttribute : ValidationAttribute, IClientModelValidator
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var itemVM = (ItemViewModel)validationContext.ObjectInstance;

            var itemService = (IService<ItemViewModel>)validationContext
                                                            .GetService(typeof(IService<ItemViewModel>));

            if (itemService.Duplicate(itemVM.Id, itemVM.Nome))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            var error = FormatErrorMessage(context.ModelMetadata.GetDisplayName());
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-error", error);
        }
    }
}

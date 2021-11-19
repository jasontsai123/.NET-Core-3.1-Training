using FluentValidation;
using Training2020WithNorthwind.Application.Controllers.Models.Parameter;

namespace Training2020WithNorthwind.Application.Infrastructure.Validators.ParameterValidators
{
    public class CustomerParameterValidator : AbstractValidator<CustomerParameter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerParameterValidator"/> class.
        /// </summary>
        public CustomerParameterValidator()
        {
            this.RuleFor(x => x.CustomerID)
                .NotNull()
                .WithMessage(ErrorMessageFormat.NotNull("顧客"))
                .NotEmpty()
                .WithMessage(ErrorMessageFormat.NotEmpty("顧客"))
                .MaximumLength(5)
                .WithMessage(ErrorMessageFormat.NotGreaterThanMaxStringLength("顧客", 5));

            this.RuleFor(x => x.CompanyName)
                .NotNull()
                .WithMessage(ErrorMessageFormat.NotNull("公司"))
                .NotEmpty()
                .WithMessage(ErrorMessageFormat.NotEmpty("公司"))
                .MaximumLength(40)
                .WithMessage(ErrorMessageFormat.NotGreaterThanMaxStringLength("公司", 40));

            this.RuleFor(x => x.ContactName)
                .MaximumLength(30)
                .WithMessage(ErrorMessageFormat.NotGreaterThanMaxStringLength("聯絡人", 30));

            this.RuleFor(x => x.Address)
                .MaximumLength(60)
                .WithMessage(ErrorMessageFormat.NotGreaterThanMaxStringLength("地址", 60));

            this.RuleFor(x => x.City)
                .MaximumLength(15)
                .WithMessage(ErrorMessageFormat.NotGreaterThanMaxStringLength("城市", 15));

            this.RuleFor(x => x.PostalCode)
                .MaximumLength(10)
                .WithMessage(ErrorMessageFormat.NotGreaterThanMaxStringLength("郵遞區號", 10));

            this.RuleFor(x => x.Country)
                .MaximumLength(15)
                .WithMessage(ErrorMessageFormat.NotGreaterThanMaxStringLength("國籍", 15));

            this.RuleFor(x => x.Phone)
                .MaximumLength(24)
                .WithMessage(ErrorMessageFormat.NotGreaterThanMaxStringLength("電話", 24));

            this.RuleFor(x => x.Fax)
                .MaximumLength(24)
                .WithMessage(ErrorMessageFormat.NotGreaterThanMaxStringLength("傳真", 24));

        }
    }
}
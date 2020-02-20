//using FluentValidation;
//using Microsoft.Extensions.Options;
//using CompanyApi.Web.Models;

//namespace CompanyApi.Web.Validators
//{
//    public class CompanyViewModelValidator : AbstractValidator<CompanyViewModel>
//    {
//        public CompanyViewModelValidator(IOptions<CompanySettings> settings)
//        {
//            var maximumUserNumber = settings.Value.MaximumUserNumber;

//            RuleFor(x => x.Name).NotNull();
//            RuleFor(x => x.Users).Must(list => list.Count <= maximumUserNumber)
//                .WithMessage($"The company must contain less than or equal to {maximumUserNumber} users");
//        }
//    }
//}
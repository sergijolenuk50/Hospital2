using FluentValidation;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Validations
{
    public class DoctorValidator: AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.FirstName)
               .NotEmpty()
               .MinimumLength(2)
               .Matches("[A-Z].*").WithMessage("{PropertyFirstName} must starts with uppercase letter.");
            RuleFor(x => x.LastName)
                .NotEmpty()
               .MinimumLength(2)
               .Matches("[A-Z].*").WithMessage("{PropertyLastName} must starts with uppercase letter.");
            RuleFor(x => x.Name)
               .NotEmpty()
              .MinimumLength(2)
              .Matches("[A-Z].*").WithMessage("{PropertyLastName} must starts with uppercase letter.");
            RuleFor(x => x.Birthday)
            .NotNull();
            
          

            RuleFor(x => x.CategoryId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            
            RuleFor(x => x.ImageUrl).Must(LinkMustBeAUri).WithMessage("Inage url address must be valid.");
        }

        private static bool LinkMustBeAUri(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            //Courtesy of @Pure.Krome's comment and https://stackoverflow.com/a/25654227/563532
            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}

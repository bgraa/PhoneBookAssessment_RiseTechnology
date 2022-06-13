using FluentValidation;
using PhoneBookAssessment.ContactAPI.Models;

namespace PhoneBookAssessment.ContactAPI.Validators
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {

        }
    }
}
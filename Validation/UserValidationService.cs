using FluentValidation;
using FluentValidation.Results;
using TimeSheets.GB.Controllers.Models;
using TimeSheets.GB.Services.Interfaces;

namespace TimeSheets.GB.Validation
{
    public class UserValidationService : AbstractValidator<UserDto>
    {
        private readonly IUserService _userService;

        /// <summary>
        /// ^                 # start-of-string
        /// (?=.*[0-9])       # a digit must occur at least once
        /// (?=.*[a-z])       # a lower case letter must occur at least once
        /// (?=.*[A-Z])       # an upper case letter must occur at least once
        /// (?=.*[@#$%^&+=])  # a special character must occur at least once
        /// (?=\S+$)          # no whitespace allowed in the entire string
        /// .{8,}             # anything, at least eight places though
        /// $                 # end-of-string
        /// </summary>
        private const string PasswordRule = @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=])(?=\S+$).{8,}$";

        public UserValidationService(IUserService userService)
        {
            _userService = userService;

            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Имя не должно быть пустым")
                .WithErrorCode("VAL-001.1");

            RuleFor(u => u.Name)
                .MinimumLength(3)
                .WithMessage("Имя должно быть длиннее 3-х букв")
                .WithErrorCode("VAL-001.2");

            RuleFor(u => u.Name)
                .MaximumLength(25)
                .WithMessage("Имя должно быть не более 25-и букв")
                .WithErrorCode("VAL-001.3");

            RuleFor(u => u.Name)
                .Custom((username, context) =>
                {
                    if (!_userService.IsUserNameUnique(username))
                    {
                        context.AddFailure(new ValidationFailure(nameof(UserDto.Name), "Пользователь уже существует!")
                        {
                            ErrorCode = "VAL-001.4"
                        });
                    }
                });

            RuleFor(u => u.Password)
                .Matches(PasswordRule)
                .WithMessage(@"Пароль не может быть короче 8-ми знаков,
должен содержать, как минимум:
одну большую букву и одну маленькую букву (лат.),
одну цифру и один из знаков (@#$%^&+=)")
                .WithErrorCode("VAL-001.5");
        }
    }
}

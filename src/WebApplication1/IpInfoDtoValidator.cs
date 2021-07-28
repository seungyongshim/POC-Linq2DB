using FluentValidation;

namespace WebApplication1
{
    public class IpInfoDtoValidator : AbstractValidator<IpInfoDto>
    {
        public IpInfoDtoValidator()
        {
            RuleFor(x => x.IpAddress).Matches(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");
        }
    }
}

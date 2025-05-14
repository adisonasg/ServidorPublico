// Application/Servidores/Commands/CreateServidorCommandValidator.cs
using FluentValidation;
using ServidorPublico.Application.Servidores.Commands.Create;

public class CreateServidorCommandValidator : AbstractValidator<CreateServidorCommand>
{
    public CreateServidorCommandValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório.");
        RuleFor(x => x.OrgaoId).NotEmpty().WithMessage("Orgão é obrigatório.");
        RuleFor(x => x.LotacaoId).NotEmpty().WithMessage("Lotação é obrigatória.");
        RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email));
    }
}

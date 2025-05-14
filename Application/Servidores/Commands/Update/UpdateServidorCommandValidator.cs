using FluentValidation;

namespace ServidorPublico.Application.Servidores.Commands.Update;

public class UpdateServidorCommandValidator : AbstractValidator<UpdateServidorCommand>
{
    public UpdateServidorCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório.");
        RuleFor(x => x.OrgaoId).NotEmpty().WithMessage("O órgão é obrigatório.");
        RuleFor(x => x.LotacaoId).NotEmpty().WithMessage("A lotação é obrigatória.");
        RuleFor(x => x.Email).EmailAddress().When(x => !string.IsNullOrEmpty(x.Email));
    }
}

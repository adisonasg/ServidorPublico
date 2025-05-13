using FluentValidation;

namespace ServidorPublico.Application.Servidores.Commands.Create;

public class CreateServidorCommandValidator : AbstractValidator<CreateServidorCommand>
{
    public CreateServidorCommandValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório");
        RuleFor(x => x.OrgaoId).NotEmpty().WithMessage("OrgaoId é obrigatório");
        RuleFor(x => x.LotacaoId).NotEmpty().WithMessage("LotacaoId é obrigatório");
    }
}

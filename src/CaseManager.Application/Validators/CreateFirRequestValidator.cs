using FluentValidation;
using CaseManager.Application.DTOs;

namespace CaseManager.Application.Validators;

public class CreateFirRequestValidator : AbstractValidator<CreateFirRequest>
{
    public CreateFirRequestValidator()
    {
        RuleFor(x => x.ComplainantName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.ComplainantPhone).NotEmpty().MaximumLength(15);
        RuleFor(x => x.CrimeType).NotEmpty();
        RuleFor(x => x.IncidentDateTime).NotEmpty();
        RuleFor(x => x.StationId).NotEmpty();
        RuleFor(x => x.StateCode).NotEmpty();
        RuleFor(x => x.CreatedBy).NotEmpty();
    }
}
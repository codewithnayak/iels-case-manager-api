using FluentValidation;
using CaseManager.Application.DTOs;

namespace CaseManager.Application.Validators;

public class CaseSearchRequestValidator : AbstractValidator<CaseSearchRequest>
{
    public CaseSearchRequestValidator()
    {
        // CrimeType is optional, but if provided, validate it
        RuleFor(x => x.CrimeType)
            .MaximumLength(50)
            .WithMessage("CrimeType cannot exceed 50 characters.");

        // Status is optional, but validate allowed values if provided
        RuleFor(x => x.Status)
            .Must(status => string.IsNullOrEmpty(status) ||
                            new[] { "Investigation", "Trial", "Closed", "Pending" }
                                .Contains(status))
            .WithMessage("Status must be one of: Investigation, Trial, Closed, Pending.");

        // Officer is optional, but validate length
        RuleFor(x => x.Officer)
            .MaximumLength(50)
            .WithMessage("Officer name cannot exceed 50 characters.");
    }
}
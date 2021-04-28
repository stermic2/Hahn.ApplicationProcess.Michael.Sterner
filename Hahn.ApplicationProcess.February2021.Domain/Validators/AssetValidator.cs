using System;
using FluentValidation;
using Hahn.ApplicationProcess.February2021.Domain.Models.Asset;

namespace Hahn.ApplicationProcess.February2021.Domain.Validators
{
    public class AssetValidator : AbstractValidator<AssetDto>
    {
        public AssetValidator()
        {
            RuleFor(x => x.AssetName).MinimumLength(5);
            RuleFor(x => x.Department).IsInEnum();
            RuleFor(x => x.CountryOfDepartment).NotEmpty().Country();
            RuleFor(x => x.PurchaseDate).NotEmpty().GreaterThan(x => DateTime.Now.AddYears(-1));
            RuleFor(x => x.EMailAddressOfDepartment).EmailAddress();
            RuleFor(x => x.Broken).NotNull();
        }
    }
}
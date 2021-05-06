using System;
using FluentValidation;
using Hahn.ApplicationProcess.February2021.Domain.Containers.Wrappers;
using Hahn.ApplicationProcess.February2021.Domain.Models.Asset;

namespace Hahn.ApplicationProcess.February2021.Domain.Validators
{
    public class AssetValidator : AbstractValidator<FormioJson<AssetDto>>
    {
        public AssetValidator()
        {
            RuleFor(x => x.data.AssetName).MinimumLength(5);
            RuleFor(x => x.data.Department).IsInEnum();
            RuleFor(x => x.data.CountryOfDepartment).NotEmpty().Country();
            RuleFor(x => x.data.PurchaseDate).NotEmpty().GreaterThan(x => DateTime.Now.AddYears(-1));
            RuleFor(x => x.data.EMailAddressOfDepartment).EmailAddress();
            RuleFor(x => x.data.Broken).NotNull();
        }
    }
}
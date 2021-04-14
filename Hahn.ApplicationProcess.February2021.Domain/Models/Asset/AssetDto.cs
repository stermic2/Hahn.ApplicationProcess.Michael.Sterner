using System;
using DynamicCQ.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.Containers.Enums;

namespace Hahn.ApplicationProcess.February2021.Domain.Models.Asset
{
    public class AssetDto : IDto
    {
        public string Id { get; set; }
        public string AssetName { get; set; }
        public Department Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EMailAddressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Broken { get; set; }
    }
}
using System;
using DynamicCQ;
using Hahn.ApplicationProcess.February2021.Domain.Containers.Enums;

namespace Hahn.ApplicationProcess.February2021.Domain.Models.Asset
{
    public class AssetEntity : Entity
    {
        public string AssetName { get; set; }
        public Department Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EMailAddressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Broken { get; set; }
    }
}
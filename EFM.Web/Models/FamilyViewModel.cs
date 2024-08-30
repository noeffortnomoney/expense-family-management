using EFM.Common;
using EFM.Common.Helpers;
using EFM.Common.Resources;
using EFM.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFM.Web.Models
{
    public class FamilyViewModel
    {
        public int FamilyID { get; set; }
        [LocalizedDisplayName("FamilyName", NameResourceType = typeof(AllResources))]
        public string FamilyName { get; set; }
        [LocalizedDisplayName("Quantity", NameResourceType = typeof(AllResources))]
        public int Quantity { get; set; }

        [LocalizedDisplayName("OrderNumber", NameResourceType = typeof(AllResources))]
        public int OrderNumber { get; set; }
    }
}
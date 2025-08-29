using EFM.Common;
using EFM.Common.Helpers;
using EFM.Common.Resources;
using EFM.Web.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFM.Web.Models
{
    public class CategoryViewModel
    {
        [LocalizedDisplayName("CategoryID", NameResourceType = typeof(AllResources))]
        public int CategoryID { get; set; }

        [LocalizedDisplayName("CategoryName", NameResourceType = typeof(AllResources))]
        public string CategoryName { get; set; }

        [LocalizedDisplayName("CategoryCode", NameResourceType = typeof(AllResources))]
        public string CategoryCode { get; set; }
        
        [LocalizedDisplayName("Description", NameResourceType = typeof(AllResources))]
        public string Description { get; set; }

        [LocalizedDisplayName("Image", NameResourceType = typeof(AllResources))]
        public string Image {  get; set; }

        [LocalizedDisplayName("CategoryParentID", NameResourceType = typeof(AllResources))]
        public int? CategoryParentID { get; set; }

        [LocalizedDisplayName("CategoryColor", NameResourceType = typeof(AllResources))]
        public string CategoryColor { get; set; }
        [LocalizedDisplayName("SelectedIcon", NameResourceType = typeof(AllResources))]
        public string SelectedIcon { get; set; }
        public CategoryType Type { get; set; }

        [LocalizedDisplayName("OrderNumber", NameResourceType = typeof(AllResources))]
        public int OrderNumber { get; set; }
    }
}
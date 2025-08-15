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
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        [LocalizedDisplayName("CategoryID", NameResourceType = typeof(AllResources))]       
        public string CategoryName { get; set; }
        [LocalizedDisplayName("CategoryName", NameResourceType = typeof(AllResources))]
        public string CategoryCode { get; set; }
        [LocalizedDisplayName("CategoryCode", NameResourceType = typeof(AllResources))]
        public string Description { get; set; }
        [LocalizedDisplayName("Description", NameResourceType = typeof(AllResources))]
        public string Image {  get; set; }

        [LocalizedDisplayName("Image", NameResourceType = typeof(AllResources))]
        public int OrderNumber { get; set; }
        [LocalizedDisplayName("OrderNumber", NameResourceType = typeof(AllResources))]
        public string ParentCategory { get; set; }
        public string CategoryColor { get; set; }
        public string SelectedIcon { get; set; }
        public CategoryType Type { get; set; }
    }
}
using System;

namespace EFM.Model.Abstract
{
    public interface IAuditable
    {
        DateTime CreatedDate { get; set; }
        int CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        int? UpdatedBy { get; set; }
        DateTime? DeletedDate { get; set; }
        int? DeletedBy { get; set; }
    }
}
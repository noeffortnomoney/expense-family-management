using System;

namespace EFM.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { set; get; }
        int CreatedBy { set; get; }
        DateTime? UpdatedDate { set; get; }
        int UpdatedBy { set; get; }
        DateTime? DeletedDate { set; get; }
        int DeletedBy { set; get; }
    }
}
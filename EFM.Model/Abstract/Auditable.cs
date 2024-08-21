using System;
using System.ComponentModel.DataAnnotations;

namespace EFM.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? CreatedDate { set; get; }
        public int CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }
        public int UpdatedBy { set; get; }

        public DateTime? DeletedDate { set; get; }

        public int DeletedBy { set; get; }
    }
}
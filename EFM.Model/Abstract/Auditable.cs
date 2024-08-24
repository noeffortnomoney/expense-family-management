using System;
using System.ComponentModel.DataAnnotations;

namespace EFM.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public int? DeletedBy { get; set; }
    }
}
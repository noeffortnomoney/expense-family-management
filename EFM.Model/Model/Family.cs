using EFM.Model.Abstract;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFM.Model.Model
{
    [Table("Family")]
    public class Family : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FamilyID { get; set; }

        [Required]
        [StringLength(100)]
        public string FamilyName { get; set; }

        public virtual ICollection<FamilyMember> FamilyMembers { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }

    }
}
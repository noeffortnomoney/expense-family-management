using EFM.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EFM.Common;

namespace EFM.Model.Model
{
    [Table("Category")]
    public class Category : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(50)]
        public string CategoryCode { get; set; }
        public string Image {  get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(50)]
        public string CategoryColor { get; set; }

        [StringLength(50)]
        public string Icon { get; set; }

        [Required]
        public CategoryType Type { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }

    }
}
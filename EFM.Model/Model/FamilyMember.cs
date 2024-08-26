using EFM.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFM.Model.Model
{
    [Table("FamilyMembers")]
    public class FamilyMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FamilyMemberID { get; set; }

        [Required]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [Required]
        public int FamilyID { get; set; }
     
        [ForeignKey("FamilyID")]
        public virtual Family Family { get; set; }

        [Required]
        public string Role { get; set; }
    }
}

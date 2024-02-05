using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ParentModel
{
    [Table(nameof(ParentClass))]
    [Index(nameof(SomeIdentifierID), nameof(ParentClassName), IsUnique = true)]
    public class ParentClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParentClassID { get; set; }

        public int SomeIdentifierID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ParentClassName { get; set; }
    }
}

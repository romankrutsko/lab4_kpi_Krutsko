using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSklad.Orchestrators.GlobalSklad.Contract
{
    public class GlobalSklad
    {
        [Required] [Column("id")] public int Id { get; set; }
        [MinLength(1)]
        [MaxLength(255)]
        [Required] [Column("name_of_item")] public string NameOfThing { get; set; }
        [Required] [Column("count")] public int Count { get; set; }
        [MinLength(1)]
        [MaxLength(255)]
        [Required] [Column("location")] public string Location { get; set; }
        [Required]
        [Column("description")]
        [MinLength(1)]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
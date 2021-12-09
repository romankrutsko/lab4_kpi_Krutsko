using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSklad.Orchestrators.LocalStore.Contract
{
    public class LocalStore
    {
        [Required] [Column("id")] public int Id { get; set; }

        [Required] [Column("location")] public string Location { get; set; }

        [Required] [Column("naming")] public string Naming { get; set; }

        [Required] [Column("count")] public int Count { get; set; }
        
        [Required] [Column("skladId")] public int SkladId { get; set; }
    }
}
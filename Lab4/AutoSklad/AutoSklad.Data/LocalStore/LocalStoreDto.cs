using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoSklad.Data.GlobalSklad;

namespace AutoSklad.Data.LocalStore
{
    [Table("local_store")]
    public class LocalStoreDto
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("location")] public string Location { get; set; }

        [Column("naming")] public string Naming { get; set; }

        [Column("count")] public int Count { get; set; }

        [ForeignKey("Sklad")]
        [Column("sklad_id")]
        public int SkladId { get; set; }

        public GlobalSkladDto Sklad { get; set; }
    }
}
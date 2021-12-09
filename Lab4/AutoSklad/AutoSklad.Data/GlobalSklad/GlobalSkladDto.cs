using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoSklad.Data.LocalStore;

namespace AutoSklad.Data.GlobalSklad
{
    [Table("sklad")]
    public class GlobalSkladDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name_of_item")] public string NameOfThing { get; set; }

        [Column("count")] public int Count { get; set; }

        [Column("location")] public string Location { get; set; }

        [Column("description")] public string Description { get; set; }

        public virtual ICollection<LocalStoreDto> Store { get; set; }
    }
}
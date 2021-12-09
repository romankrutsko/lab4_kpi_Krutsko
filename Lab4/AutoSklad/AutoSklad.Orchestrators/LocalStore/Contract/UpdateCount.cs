using System.ComponentModel.DataAnnotations;

namespace AutoSklad.Orchestrators.LocalStore.Contract
{
    public class UpdateCount
    {
        [Required]
        public int Count { get; set; }
    }
}
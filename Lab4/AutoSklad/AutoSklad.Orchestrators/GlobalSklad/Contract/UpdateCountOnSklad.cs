using System.ComponentModel.DataAnnotations;

namespace AutoSklad.Orchestrators.GlobalSklad.Contract
{
    public class UpdateCountOnSklad
    {
        [Required] public int Count { get; set; }
    }
}
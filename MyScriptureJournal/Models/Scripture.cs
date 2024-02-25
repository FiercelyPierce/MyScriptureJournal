using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public required string Book { get; set; }

        [Required]
        public int Chapter { get; set; }

        [Required]
        public int Verse { get; set; }

        public string? Note { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }
    }
}

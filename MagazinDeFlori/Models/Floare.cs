using System.ComponentModel.DataAnnotations;

namespace MagazinDeFlori.Models
{
    public class Floare
    {
        [Key]
        public int CodFloare { get; set; }
        public string? Denumire { get; set; }
        public string? Descriere { get; set; }
        public double Pret { get; set; }
        public string? Imagime { get; set; }
    }
}

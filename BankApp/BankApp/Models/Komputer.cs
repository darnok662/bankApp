using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class Komputer
    {
        public string? Nazwa { get; set; }
        
        public DateTime DataKsiegowania { get; set; }

        public int KosztUSD { get; set; }

        public int KosztPLN { get; set; }

        public int Kurs { get; set; }
    }
}

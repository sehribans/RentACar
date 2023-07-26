using Microsoft.EntityFrameworkCore;

namespace RentACar.Models.Views
{
    [Keyless]
    public class RentView
    {
        public int ID { get; set; }

        public string? ARAC_AD { get; set; }

        public string? GORSEL { get; set; }

        public string? VİTES { get; set; }

        public string? YAKIT { get; set; }

        public int? KM { get; set; }

        public short? YIL { get; set; }

        public byte? KOLTUK { get; set; }

        public decimal? KİRA { get; set; }

        public int? MARKA_ID { get; set; }

        public string? MARKA { get; set; }
        public string? ICON { get; set; }


        public string? SEHIR_AD { get; set; }
    }

    }

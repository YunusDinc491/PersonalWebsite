namespace PersonalWebsite.Models
{
    public class Proje
    {
        public int Id { get; set; }

        public string ProjeAdi { get; set; }
        public string ProjeAciklama { get; set; }

        public string KullanilanTeknolojiler { get; set; }

        public string ProjeFoto { get; set; }
        public string? DemoUrl { get; set; }
        public string? KaynakKodUrl { get; set; }
        public string? Kategori { get; set; }

    }
}

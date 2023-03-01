namespace Lager.Models
{
    public class PluklisteFrontModelfuck
    {
        public int FakturaNummer { get; set; }
        public int KundeID { get; set; }
        public string? Forsendelse { get; set; }
        public bool Label { get; set; }
        public string? Print { get; set; }

        public enum PlukTypes { FakturaNummer, KundeID, Forsendelse, Label, Print }
    }
}

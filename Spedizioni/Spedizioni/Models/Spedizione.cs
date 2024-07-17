namespace Spedizioni.Models
{
    public class Spedizione
    {
        public int Id { get; set; }
        public string NumeroIdentificativo { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataSpedizione { get; set; }
        public decimal Peso { get; set; }
        public string CittàDestinataria { get; set; }
        public string IndirizzoDestinatario { get; set; }
        public string NominativoDestinatario { get; set; }
        public decimal CostoSpedizione { get; set; }
        public DateTime DataConsegnaPrevista { get; set; }
    }
}

namespace AdaTech.EncurtadorDeLinks.WebAPI.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string UrlOriginal { get; set; }
        public string UrlCurta { get; set; }
        public DateTime Validade { get; set; }

    }
}

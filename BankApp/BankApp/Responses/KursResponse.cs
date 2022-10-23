namespace BankApp.Responses
{
    public class KursResponse
    {
        public string Table { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public IList<Rates> Rates { get; set; }
        public float GetMidKurs()
        {
            return Rates[0].Mid;
        }
    }
}

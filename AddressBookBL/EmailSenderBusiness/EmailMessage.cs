namespace AddressBookBL.EmailSenderBusiness
{
    public class EmailMessage
    {
        public string[] To { get; set; } //kime
        public string Subject { get; set; } //konu
        public string Body { get; set; } //içerik
        public string[] CC { get; set; }
        public string[] BCC { get; set; }
    }
}

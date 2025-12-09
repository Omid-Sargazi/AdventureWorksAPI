namespace DesignPatternsInCSharp.StructuraDesignPattern
{
    public interface IEmailSender
    {
        void SendEmail(string subject, string body);
    }

    public abstract class Email
    {
        public IEmailSender MesaageSender{get;set;}
        public string Subject {get;set;}
        public string Body {get;set;}
        public abstract void Send();
    }
}
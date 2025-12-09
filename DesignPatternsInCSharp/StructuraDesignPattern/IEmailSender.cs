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

    public class SystemEmail : Email
    {
        public override void Send()
        {
            string emailSubject = string.Format("Subject: {0} from System", Subject);
 
            string emailBody = string.Format("Email Body:\n{0}", Body);

            MesaageSender.SendEmail(emailSubject,emailBody);
        }
    }

    public class UserEmail : Email
    {
        public override void Send()
        {
            string emailSubject = string.Format("Subject: {0} from User", Subject);
 
  
 
       string emailBody = string.Format("Email Body:\n{0}", Body);
 
  
 
         MesaageSender.SendEmail(emailSubject, emailBody);
        }
    }

}
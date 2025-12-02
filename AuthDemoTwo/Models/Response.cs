namespace AuthDemoTwo.Models
{
    public class Response
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }

    public class LoginResponse
    {
        public string Message {get;set;}
        public string Role {get;set;}
        public string Email {get;set;}
    }
}
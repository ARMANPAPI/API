namespace CityInfo.API.Service
{
    public class localMailService : IMailService
    {
        private readonly string _mailTo =string.Empty;
        private readonly string _mailfrom = string.Empty;


        public localMailService(IConfiguration configuration)
        {
            //Read appsettings.json For Publish
            _mailTo = configuration["setingForEmailSender:mailToAddress"];
            _mailfrom = configuration["setingForEmailSender:mailFromAddress"];
        }


        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail From {_mailfrom} To {_mailTo} ,"
                + $"{nameof(localMailService)}  ,  ");
            Console.WriteLine($"Sbject {subject}");
            Console.WriteLine($"Message {message}");
        }
    }
}

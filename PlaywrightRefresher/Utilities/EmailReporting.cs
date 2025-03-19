using System.Net;
using System.Net.Mail;


public static class EmailReporter
{
    public static void SendTestReport(string subject, string body)
    {
        try
        {
            using (var client = new SmtpClient("smtp.your-email-provider.com"))  // Replace with your SMTP server
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential("your-email@example.com", "your-email-password"); // ⚠️ Use secure credentials handling
                client.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("your-email@example.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };

                mailMessage.To.Add("recipient-email@example.com");

                client.Send(mailMessage);
                Console.WriteLine("✅ Test report email sent successfully!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Failed to send test report: {ex.Message}");
        }
    }
}

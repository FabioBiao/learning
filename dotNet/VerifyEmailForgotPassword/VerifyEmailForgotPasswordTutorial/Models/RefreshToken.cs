namespace SimpleEmailApp.Models
{
    public class RefreshToken
    {
        // id here and a flag, to identify a invalid token 
        public required string Token { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Expires { get; set; }
    }
}

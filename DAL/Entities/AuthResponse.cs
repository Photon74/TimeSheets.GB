namespace TimeSheets.GB.DAL.Entities
{
    public class AuthResponse
    {
        public string Password { get; set; }

        public TokenEntity LatestRefreshToken { get; set; }
    }
}

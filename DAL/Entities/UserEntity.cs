namespace TimeSheets.GB.DAL.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public TokenEntity Token { get; set; }
    }
}

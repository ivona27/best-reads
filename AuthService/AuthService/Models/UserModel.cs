namespace AuthService.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
    }
}

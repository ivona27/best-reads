﻿namespace AuthService.Models
{
    public class AuthModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; } 
        public string email { get; set; } 
        public string password { get; set; }
    }
}
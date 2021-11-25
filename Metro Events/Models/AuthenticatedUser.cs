using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metro_Events.Models
{
    public class AuthenticatedUser
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Is_gorganizer { get; set; }
        public string Is_admin { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}

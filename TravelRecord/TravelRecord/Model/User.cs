using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TravelRecord.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        [NotNull]
        public string Email { get; set; }

        [NotNull]
        public string Password { get; set; }

        [NotNull]
        public string Username { get; set; }
    }
}

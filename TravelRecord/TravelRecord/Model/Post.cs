﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TravelRecord.Model
{
    public class Post
    {
        [MaxLength(250)]
        public string Experience { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}

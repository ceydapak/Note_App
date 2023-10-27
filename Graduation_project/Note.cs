﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation_project
{
    public class Note
    {
       [PrimaryKey, AutoIncrement]
        public  int Id { get; set; }
        public  string Title { get; set; } 
        public  string Description { get; set; }
        public  DateTime Date { get; set; }
        public  string File { get; set; }
        public string User { get; set; }
    }
}

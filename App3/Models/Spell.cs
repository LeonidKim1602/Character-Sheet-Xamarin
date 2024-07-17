using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class Spell
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }
        public string CastingTime { get; set; }
        public string Name { get; set; }
        public string Distance { get; set; }
        public string Components { get; set; }
        public string Duration { get; set; }
        public string Classes { get; set; }
        public string Description { get; set; }

    }
}

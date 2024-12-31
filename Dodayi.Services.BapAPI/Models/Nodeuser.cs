﻿namespace Dodayi.Services.BapAPI.Models
{
    public partial class Nodeuser
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int? Corpnodeid { get; set; }

        // Navigation Properties
        public virtual Corpnode? Corpnodes { get; set; }
        //public User? User { get; set; } // Relation to User table (if applicable)
    }
}

namespace Dodayi.Services.PersonAPI.Models
{
    public partial class Nodeuser
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int? Corpnodeid { get; set; }

        // Navigation Properties
        public virtual Corpnode? Corpnode { get; set; }
        //public User? User { get; set; } // Relation to User table (if applicable)
    }
}

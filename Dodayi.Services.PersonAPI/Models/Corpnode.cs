namespace Dodayi.Services.PersonAPI.Models
{
    public partial class Corpnode
    {
        public Corpnode()
        {
            Nodeusers = new HashSet<Nodeuser>();

        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //
        public int ParentId { get; set; }
        public Corpnode? Parent { get; set; }
        //

        public int? Nodetypeid { get; set; }
        public int? UstId { get; set; }
        public int? Kod { get; set; }
        public bool? Temp { get; set; }
        public bool? Tip { get; set; }
        public string? BounKod { get; set; }
        public int? DoktoraProgrami { get; set; }
        public string? YukseltmeKriteri { get; set; }
        public bool? Fen { get; set; }
        public bool? Sosyal { get; set; }
        public int? YeniId { get; set; }
        public bool? FenOther { get; set; }
        public bool? SosyalOther { get; set; }
        public bool? TemelBilimler { get; set; }
        public bool? TeknikBilimler { get; set; }
        public bool? OncelikliAlan { get; set; }
        public int? Enstitu { get; set; }

        public virtual Nodetype? Nodetype { get; set; }
        public virtual ICollection<Nodeuser> Nodeusers { get; set; }

        //public virtual ICollection<Corpnode>? Children { get; set; }

    }
}

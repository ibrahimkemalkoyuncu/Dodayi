namespace Dodayi.Services.PersonAPI.Models
{
    public partial class Nodetype
    {
        public Nodetype()
        {
            Corpnodes = new HashSet<Corpnode>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Corpnode> Corpnodes { get; set; }


    }
}

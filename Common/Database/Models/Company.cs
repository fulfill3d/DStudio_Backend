namespace DStudio.Common.Database.Models
{
    public partial class Company
    {
        public Company()
        {
            Apps = new HashSet<App>();
        }

        public int Id { get; set; }
        public Guid RefId { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsEnabled { get; set; }

        public virtual ICollection<App> Apps { get; set; }
    }
}

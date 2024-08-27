namespace DStudio.Common.Database.Models
{
    public partial class App
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? TokenRefreshedAt { get; set; }
        public bool IsTokenRevoked { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsEnabled { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}

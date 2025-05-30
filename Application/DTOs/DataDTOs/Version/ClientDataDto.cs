namespace Application.DTOs.DataDTOs.Version
{
    public class ClientDataDto
    {
        public string Name { get; set; } = default!;
        public int Version { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

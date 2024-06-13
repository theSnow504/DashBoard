
namespace Dashboard.DataDto.Action
{
    public class ActionDto
    {
        public string? FbUser { get; set; }
        public List<byte> ActionName { get; set; } = new List<byte>();
        public List<DateTime> StartTime { get; set; } = new List<DateTime>();
        public List<DateTime> ExcuteTime { get; set; } = new List<DateTime>();
        public bool Result { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
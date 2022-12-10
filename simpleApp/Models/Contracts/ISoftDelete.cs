namespace simpleApp.Models.Contracts
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}

namespace PetAPI
{
    public class PetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactDetails { get; set; }
        public string LostAt { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFound { get; set; }
    }

}

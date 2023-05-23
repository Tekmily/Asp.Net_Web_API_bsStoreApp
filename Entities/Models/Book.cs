namespace Entities.Models
{
    public class Book
    {
        public int Id { get; set; }
        public String? Title { get; set; }
        public decimal Price { get; set; }
        //Ref: Navigation Property
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
namespace HotwireApplication.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string AuthorImageUrl { get; set; }
        public string Author { get; set; }
        public string PostedAt { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Likes { get; set; }
        public int Replies { get; set; }
        public float Views { get; set; }
    }
}
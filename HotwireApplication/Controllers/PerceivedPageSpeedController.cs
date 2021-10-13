using System.Collections.Generic;
using HotwireApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotwireApplication.Controllers
{
    public class PerceivedPageSpeedController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var questions = new List<Question>
            {
                new Question() {
                    Id = 11111,
                    AuthorImageUrl = "https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80",
                    Author = "Dries Vincent",
                    PostedAt = "December 9 at 11:43 AM",
                    Title = "What would you have done differently if you ran Jurassic Park?",
                    Body = @"
                        <p>Jurassic Park was an incredible idea and a magnificent feat of engineering, but poor protocols and a disregard for human safety killed what could have otherwise been one of the best businesses of our generation.</p>
                        <p>Ultimately, I think that if you wanted to run the park successfully and keep visitors safe, the most important thing to prioritize would be&hellip;</p>
",
                    Likes = 29,
                    Replies = 11,
                    Views = 2.7F
                    
                    
                },
                
                new Question() {
                    Id = 11111,
                    AuthorImageUrl = "https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80",
                    Author = "Dries Vincent",
                    PostedAt = "December 9 at 11:43 AM",
                    Title = "What would you have done differently if you ran Jurassic Park?",
                    Body = @"
                        <p>Jurassic Park was an incredible idea and a magnificent feat of engineering, but poor protocols and a disregard for human safety killed what could have otherwise been one of the best businesses of our generation.</p>
                        <p>Ultimately, I think that if you wanted to run the park successfully and keep visitors safe, the most important thing to prioritize would be&hellip;</p>
",
                    Likes = 29,
                    Replies = 11,
                    Views = 2.7F
                    
                    
                },
                new Question() {
                    Id = 11111,
                    AuthorImageUrl = "https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80",
                    Author = "Dries Vincent",
                    PostedAt = "December 9 at 11:43 AM",
                    Title = "What would you have done differently if you ran Jurassic Park?",
                    Body = @"
                        <p>Jurassic Park was an incredible idea and a magnificent feat of engineering, but poor protocols and a disregard for human safety killed what could have otherwise been one of the best businesses of our generation.</p>
                        <p>Ultimately, I think that if you wanted to run the park successfully and keep visitors safe, the most important thing to prioritize would be&hellip;</p>
",
                    Likes = 29,
                    Replies = 11,
                    Views = 2.7F
                    
                    
                },
                new Question() {
                    Id = 11111,
                    AuthorImageUrl = "https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80",
                    Author = "Dries Vincent",
                    PostedAt = "December 9 at 11:43 AM",
                    Title = "What would you have done differently if you ran Jurassic Park?",
                    Body = @"
                        <p>Jurassic Park was an incredible idea and a magnificent feat of engineering, but poor protocols and a disregard for human safety killed what could have otherwise been one of the best businesses of our generation.</p>
                        <p>Ultimately, I think that if you wanted to run the park successfully and keep visitors safe, the most important thing to prioritize would be&hellip;</p>
",
                    Likes = 29,
                    Replies = 11,
                    Views = 2.7F
                    
                    
                },
                new Question() {
                    Id = 11111,
                    AuthorImageUrl = "https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80",
                    Author = "Dries Vincent",
                    PostedAt = "December 9 at 11:43 AM",
                    Title = "What would you have done differently if you ran Jurassic Park?",
                    Body = @"
                        <p>Jurassic Park was an incredible idea and a magnificent feat of engineering, but poor protocols and a disregard for human safety killed what could have otherwise been one of the best businesses of our generation.</p>
                        <p>Ultimately, I think that if you wanted to run the park successfully and keep visitors safe, the most important thing to prioritize would be&hellip;</p>
",
                    Likes = 29,
                    Replies = 11,
                    Views = 2.7F
                    
                    
                },
                new Question() {
                    Id = 11111,
                    AuthorImageUrl = "https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80",
                    Author = "Dries Vincent",
                    PostedAt = "December 9 at 11:43 AM",
                    Title = "What would you have done differently if you ran Jurassic Park?",
                    Body = @"
                        <p>Jurassic Park was an incredible idea and a magnificent feat of engineering, but poor protocols and a disregard for human safety killed what could have otherwise been one of the best businesses of our generation.</p>
                        <p>Ultimately, I think that if you wanted to run the park successfully and keep visitors safe, the most important thing to prioritize would be&hellip;</p>
",
                    Likes = 29,
                    Replies = 11,
                    Views = 2.7F
                    
                    
                },
                new Question() {
                    Id = 11111,
                    AuthorImageUrl = "https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80",
                    Author = "Dries Vincent",
                    PostedAt = "December 9 at 11:43 AM",
                    Title = "What would you have done differently if you ran Jurassic Park?",
                    Body = @"
                        <p>Jurassic Park was an incredible idea and a magnificent feat of engineering, but poor protocols and a disregard for human safety killed what could have otherwise been one of the best businesses of our generation.</p>
                        <p>Ultimately, I think that if you wanted to run the park successfully and keep visitors safe, the most important thing to prioritize would be&hellip;</p>
",
                    Likes = 29,
                    Replies = 11,
                    Views = 2.7F
                    
                    
                },
                new Question() {
                    Id = 11111,
                    AuthorImageUrl = "https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80",
                    Author = "Dries Vincent",
                    PostedAt = "December 9 at 11:43 AM",
                    Title = "What would you have done differently if you ran Jurassic Park?",
                    Body = @"
                        <p>Jurassic Park was an incredible idea and a magnificent feat of engineering, but poor protocols and a disregard for human safety killed what could have otherwise been one of the best businesses of our generation.</p>
                        <p>Ultimately, I think that if you wanted to run the park successfully and keep visitors safe, the most important thing to prioritize would be&hellip;</p>
",
                    Likes = 29,
                    Replies = 11,
                    Views = 2.7F
                    
                    
                },
                new Question() {
                    Id = 11111,
                    AuthorImageUrl = "https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80",
                    Author = "Dries Vincent",
                    PostedAt = "December 9 at 11:43 AM",
                    Title = "What would you have done differently if you ran Jurassic Park?",
                    Body = @"
                        <p>Jurassic Park was an incredible idea and a magnificent feat of engineering, but poor protocols and a disregard for human safety killed what could have otherwise been one of the best businesses of our generation.</p>
                        <p>Ultimately, I think that if you wanted to run the park successfully and keep visitors safe, the most important thing to prioritize would be&hellip;</p>
",
                    Likes = 29,
                    Replies = 11,
                    Views = 2.7F
                    
                    
                },
                new Question() {
                    Id = 11111,
                    AuthorImageUrl = "https://images.unsplash.com/photo-1506794778202-cad84cf45f1d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80",
                    Author = "Dries Vincent",
                    PostedAt = "December 9 at 11:43 AM",
                    Title = "What would you have done differently if you ran Jurassic Park?",
                    Body = @"
                        <p>Jurassic Park was an incredible idea and a magnificent feat of engineering, but poor protocols and a disregard for human safety killed what could have otherwise been one of the best businesses of our generation.</p>
                        <p>Ultimately, I think that if you wanted to run the park successfully and keep visitors safe, the most important thing to prioritize would be&hellip;</p>
",
                    Likes = 29,
                    Replies = 11,
                    Views = 2.7F
                    
                    
                },
            }; 
            return View(new PageSpeedModel()
            {
                Questions = questions
            });
        }

        public IActionResult Author()
        {
            return View();
        }
    }
}
using System;
using Microsoft.AspNetCore.Http;
namespace school.MODAL
{
    public class Photo
    {
            public string Url { get; set;}
        public IFormFile File { get; set;}

        public string Description { get; set;}
        public DateTime DateAdded { get; set;}
        public string PublicId { get; set;}
        public Photo(){
            DateAdded =  DateTime.Now;
        }
    }
}
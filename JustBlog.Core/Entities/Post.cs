﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustBlog.Core.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title must be required")]
        public string Title { get; set; }

        [StringLength(1024)]
        [Column("Short Description")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Post content must be required")]
        [Column("Post Content")]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "Url slug must be required")]
        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        [NotMapped]
        public decimal Rate { get => RateCount > 0 ? Math.Round((decimal)(TotalRate / RateCount), 2) : 0; }

        [Column("Posted On")]
        [Required(ErrorMessage = "Posted on must be required")]
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<PostTagMap> PostTagMaps { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

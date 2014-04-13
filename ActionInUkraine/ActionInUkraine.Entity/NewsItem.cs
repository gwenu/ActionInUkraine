using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActionInUkraine.Entity
{
    [Table("News")]
    public class NewsItem
    {
        [Key]
        public int ArticleID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Author
        {
            get;
            set;
        }

        public string Article
        {
            get;
            set;
        }
        public DateTime DatePublished
        {
            get;
            set;
        }
    }
}

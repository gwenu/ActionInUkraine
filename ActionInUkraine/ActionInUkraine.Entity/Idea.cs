using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ActionInUkraine.Entity
{
    [Table("Idea")]
    public class Idea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdeaID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Image
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }


        //  public virtual ICollection<SocialNetwork> SocialNetworks { get; set; }

        //    public virtual ICollection<UserProfile> Team { get; set; }

        //    public string Goals
        //    {
        //        get;
        //        set;
        //    }

        public Boolean? NeedPeople
        {
            get;
            set;
        }

        public string People
        {
            get;
            set;
        }

        public Boolean? NeedMoney
        {
            get;
            set;
        }
        public int? Money
        {
            get;
            set;
        }
        public Boolean? NeedFeedback
        {
            get;
            set;
        }
        public Boolean? NeedAdvert
        {
            get;
            set;
        }
        public Boolean? NeedSmthElse
        {
            get;
            set;
        }
        public String SmthElse
        {
            get;
            set;
        }

        //    public virtual ICollection<Expense> Expenses { get; set; }

        //    public String AlreadyIs
        //    {
        //        get;
        //        set;
        //    }
        //    public virtual ICollection<Event> Events { get; set; }

        [ForeignKey("UserProfile")]
        public virtual int UserId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }

    //public class Event
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public DateTime Date { get; set; }
    //}

    //public class Expense
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Price { get; set; }
    //}
    [Table("SNs")]
    public class SocialNetwork
    {
        public int Id { get; set; }
        public string Link { get; set; }
    }
}

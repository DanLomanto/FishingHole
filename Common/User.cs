//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.ImagePaths = new HashSet<ImagePath>();
            this.Locations = new HashSet<Location>();
            this.Threads = new HashSet<Thread>();
            this.Trips = new HashSet<Trip>();
        }
    
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ImagePath> ImagePaths { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Thread> Threads { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}

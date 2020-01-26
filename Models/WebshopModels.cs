using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDWebShop.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Subscription Subscription { get; set; }
    }

    public class Disk
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DiskType DiskType { get; set; }
        public Category Category { get; set; }
        public string ImageURL { get; set; }

    }

    public class Subscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DiskType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
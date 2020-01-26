using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CDWebShop.Models
{
    public class CreateCustomerViewModel 
    {
        [Required(ErrorMessage = "A new customer must have firstname!")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "A new customer must have lastname!")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "A new customer must have e-mail adress!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must choose the type of subscription of the new customer!")]
        public int SubscriptionId { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }

    public class EditCustomerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A new customer must have firstname!")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "A new customer must have lastname!")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "A new customer must have e-mail adress!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must choose the type of subscription of the new customer!")]
        public int SubscriptionId { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}
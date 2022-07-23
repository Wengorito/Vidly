using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Core.Domain;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Birth date")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public string Title => Id != 0 ? "Edit Customer" : "New Customer";

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Birthdate = customer.Birthdate;
            MembershipTypeId = customer.MembershipTypeId;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        }
    }
}
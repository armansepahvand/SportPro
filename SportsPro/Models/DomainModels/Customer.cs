using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using SportsPro.Models.DomainModels;

namespace SportsPro.Models
{
    public class Customer
    {
		public int CustomerID { get; set; }

		[Required(ErrorMessage = "Please enter your first name.")]
		[MinLength(1), MaxLength(50)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Please enter your last name.")]
		[MinLength(1), MaxLength(50)]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter your address.")]
		[MinLength(1), MaxLength(50)]
		public string Address { get; set; }

		[Required(ErrorMessage = "Please enter your city.")]
		[MinLength(1), MaxLength(50)]
		public string City { get; set; }

		[Required(ErrorMessage = "Please enter your state.")]
		[MinLength(1), MaxLength(50)]
		public string State { get; set; }

		[Required(ErrorMessage = "Please enter your postal code.")]
		[RegularExpression (@"^\d$", ErrorMessage = "Please enter numbers only for postal code")]
        [StringLength (5, ErrorMessage = " Postal code should have 5 digits only")]
		public string PostalCode { get; set; }


		[Required]
		public string CountryID { get; set; }

		public Country Country { get; set; }

		[Required(ErrorMessage = "Please enter your Phone number")]
		[RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}",
		ErrorMessage = "Please enter phone number in correct format, Phone must be in 999-999-9999")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Please enter a valid Email.")]
		[MinLength(1), MaxLength(50)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		public string FullName => FirstName + " " + LastName; // read-only property
		public ICollection<CustomerProduct> CustomerProducts { get; set; }
	}
}


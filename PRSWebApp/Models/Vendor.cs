using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSWebApp.Models {
	public class Vendor {

		public int VendorID { get; set; }

		[Required]
		[StringLength(10)]
		public string Code { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		[StringLength(255)]
		public string Address { get; set; }

		[Required]
		[StringLength(255)]
		public string City { get; set; }

		[Required]
		[StringLength(2)]
		public string State { get; set; }

		[Required]
		[StringLength(5)]
		public string Zip { get; set; }

		[Required]
		[StringLength(12)]
		public string Phone { get; set; }

		[Required]
		[StringLength(100)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		public Boolean Preapproved { get; set; }
	}
}
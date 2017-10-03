using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSWebApp.Models {
	public class Product {
		public int ProductID { get; set; }

		[Required]
		[StringLength(30)]
		public string VendorPartNumber { get; set; }

		[Required]
		[StringLength(30)]
		public string Name { get; set; }

		[Required]
		public double Price { get; set; }

		[Required]
		[StringLength(30)]
		public string Unit { get; set; }

		[StringLength(130)]
		public string PhotoPath { get; set; }

		public int VendorID { get; set; }
		public virtual Vendor Vendor { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSWebApp.Models {
	public class PurchaseRequestLineItem {

		[Required]
		public int PurchaseRequestLineItemID { get; set; }

		[Required]
		public int Quantity { get; set; }

		[Required]
		public int PurchaseRequestID { get; set; }
		public PurchaseRequest PurchaseRequest { get; set; }

		[Required]
		public int ProductID { get; set; }
		public Product Product { get; set; }

	}
}
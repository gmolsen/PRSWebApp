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
		//need virtual to include Purchase Request in PurchaseRequestLineItem
		public virtual PurchaseRequest PurchaseRequest { get; set; }

		[Required]
		public int ProductID { get; set; }
		//need virtual to include Product in PurchaseRequestLineItem
		public virtual Product Product { get; set; }

		// easier to find rather than digging through controller
		public void Clone(PurchaseRequestLineItem purchaseRequestLineItem) {
			ProductID = purchaseRequestLineItem.ProductID;
			//Product = purchaseRequestLineItem.Product;
			Quantity = purchaseRequestLineItem.Quantity;
			PurchaseRequestID = purchaseRequestLineItem.PurchaseRequestID;
			//PurchaseRequest = purchaseRequestLineItem.PurchaseRequest;
		}

	}
}
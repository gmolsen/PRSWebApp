using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSWebApp.Models {
	public class PurchaseRequest {
	
	[Required]
	public int PurchaseRequestID { get; set; }

	[Required]
	[StringLength(80)]
	public string Description { get; set; }

	[Required]
	[StringLength(80)]
	public string Justification { get; set; }

	[Required]
	public DateTime DateNeeded { get; set; }

	[Required]
	[StringLength(20)]
	public string DeliveryMode { get; set; }

	[Required]
	[StringLength(15)]
	public string Status { get; set; }

	[Required]
	public double Total { get; set; }

	[Required]
	public DateTime SubmittedDate { get; set; }

	[Required]
	public int UserID { get; set; }
	public User User { get; set; }
	}
}
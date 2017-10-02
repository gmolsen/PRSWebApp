using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRSWebApp.Models {
	public class PurchaseRequest {

	public int PurhcaseID { get; set; }

	[Required]
	[StringLength(30)]
	public int UserID{ get; set; }

	[Required]
	[StringLength(16)]
	public string Description { get; set; }

	[Required]
	[StringLength(30)]
	public string Justification { get; set; }

	[Required]
	[StringLength(30)]
	public DateTime DateNeeded { get; set; }

	[Required]
	[StringLength(12)]
	public string DeliveryMode { get; set; }

	[Required]
	[StringLength(30)]
	public int Status { get; set; }

	[Required]
	public double Total { get; set; }

	[Required]
	public DateTime SubmittedDate { get; set; }
	}
}
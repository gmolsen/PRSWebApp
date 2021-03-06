﻿using System;
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

	[StringLength(80)]
	public string RejectionReason { get; set; }

	[Required]
	public DateTime DateNeeded { get; set; }

	[Required]
	[StringLength(20)]
	public string DeliveryMode { get; set; }

		[Required]
		[StringLength(15)]
		public string Status { get; set; } = "New";

		public double Total { get; set; } = 0;

		[Required]
		public DateTime SubmittedDate;

	[Required]
	public int UserID { get; set; }
	//virtual tells EF to fill in User when you access it
	public virtual User User { get; set; }

		// easier to find rather than digging through controller
		// to make a copy of an object rather than have two variables that point to the same object
		public void Clone(PurchaseRequest purchaseRequest) {
			UserID = purchaseRequest.UserID;
			Description = purchaseRequest.Description;
			Justification = purchaseRequest.Justification;
			DateNeeded = purchaseRequest.DateNeeded;
			DeliveryMode = purchaseRequest.DeliveryMode;
			Status = purchaseRequest.Status;
			Total = purchaseRequest.Total;
			SubmittedDate = purchaseRequest.SubmittedDate;
		}

		}
	}
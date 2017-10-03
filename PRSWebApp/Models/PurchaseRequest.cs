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
	public string Status { get; set; }

	[Required]
	public double Total { get; set; }

	[Required]
	public DateTime SubmittedDate = DateTime.Now;

	[Required]
	public int UserID { get; set; }
	public User User { get; set; }
	
	public void Clone(PurchaseRequest purchaseRequest) {
			UserID = purchaseRequest.UserID;
			User = purchaseRequest.User;
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
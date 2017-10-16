export class PurchaseRequest {
	
	PurchaseRequestID: number;
	Description: string;
	Justification: string;
	RejectionReason: string;
	DateNeeded: Date;
	DateSubmitted: Date;
	DeliveryMode: string;
	Status: string;
	Total: number;
	UserID: number;

	constructor(
		PurchaseRequestID: number,
		Description: string,
		Justification: string,
		RejectionReason: string,
		DateNeeded: Date,
		DateSubmitted: Date,
		DeliveryMode: string,
		Status: string,
		Total: number,
		UserID: number,
	) {
		this.PurchaseRequestID = PurchaseRequestID;
		this.Description = Description;
		this.Justification = Justification;
		this.RejectionReason = RejectionReason;
		this.DateNeeded = DateNeeded;
		this.DateSubmitted = DateSubmitted;
		this.DeliveryMode = DeliveryMode;
		this.Status = Status;
		this.Total = Total;
		this.UserID = UserID;
	}
}
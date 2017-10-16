export class PurchaseRequestLineItem {
	
	PurchaseRequestLineItemID: number;
	Quantity: number;
	PurchaseRequestID: number;
	ProductID: number;

	constructor(
		PurchaseRequestLineItemID: number,
		Quantity: number,
		PurchaseRequestID: number,
		ProductID: number,
	) {
		this.PurchaseRequestLineItemID = PurchaseRequestLineItemID;
		this.Quantity = Quantity;
		this.PurchaseRequestID = PurchaseRequestID;
		this.ProductID = ProductID;
		
	}
}
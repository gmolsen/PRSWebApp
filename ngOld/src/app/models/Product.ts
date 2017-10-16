export class Product {
	
	ProductID: number;
	VendorPartNumber: string;
	Name: string;
	Price: number;
	Unit: string;
	PhotoPath: string;
	VendorID: number;

	constructor(
		ProductID: number,
		VendorPartNumber: string,
		Name: string,
		Price: number,
		Unit: string,
		PhotoPath: string,
		VendorID: number,
	) {
		this.ProductID = ProductID;
		this.VendorPartNumber = VendorPartNumber;
		this.Name = Name;
		this.Price = Price;
		this.Unit = Unit;
		this.PhotoPath = PhotoPath;
		this.VendorID = VendorID;
	}
}
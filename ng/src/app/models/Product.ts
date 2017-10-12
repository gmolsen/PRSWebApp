import { Vendor } from '../models/Vendor';

export class Product {
	
	ProductID: number;
	VendorPartNumber: string;
	Name: string;
	Price: number;
	Unit: string;
	PhotoPath: string;
	VendorID: number;
	Vendor: Vendor;

	constructor(
		ProductID: number,
		VendorPartNumber: string,
		Name: string,
		Price: number,
		Unit: string,
		PhotoPath: string,
		VendorID: number,
		Vendor: Vendor,
	) {
		this.ProductID = ProductID;
		this.VendorPartNumber = VendorPartNumber;
		this.Name = Name;
		this.Price = Price;
		this.Unit = Unit;
		this.PhotoPath = PhotoPath;
		this.VendorID = VendorID;
		this.Vendor = Vendor;
	}
}
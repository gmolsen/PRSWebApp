export class Vendor {
	
	VendorID: number;
	Code: string;
	Name: string;
	Address: string;
	City: string;
	State: string;
	Zip: string;
	Phone: string;
	Email: string;
	IsPreapproved: boolean;

	constructor(
		VendorID: number,
		Code: string,
		Name: string,
		Address: string,
		City: string,
		State: string,
		Zip: string,
		Phone: string,
		Email: string,
		IsPreapproved: boolean,
	) {
		this.VendorID = VendorID;
		this.Code = Code;
		this.Name = Name;
		this.Address = Address;
		this.City = City;
		this.State = State;
		this.Zip = Zip;
		this.Phone = Phone;
		this.Email = Email;
		this.IsPreapproved = IsPreapproved;
	}
}
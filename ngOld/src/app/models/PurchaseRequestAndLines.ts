import { PurchaseRequestLineItem } from '../models/PurchaseRequestLineItem';
import { PurchaseRequest} from '../models/PurchaseRequest';

export class PurchaseRequestAndLines {
	
	PurchaseRequest: PurchaseRequest;
	PurchaseRequestLineItems: PurchaseRequestLineItem[];
	
}
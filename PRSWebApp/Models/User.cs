using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRSWebApp.Models {
	// a class is a description of a datatype, an instance is an object of a datatype
	public class User {
		//get hidden variable, set hidden variable - works best with EF

		public int UserID { get; set; }

		[Required]
		[StringLength(30)]
		//requires username to be unique
		[Index(IsUnique = true)]
		public string UserName { get; set; }

		//public int myVar; -- this is a field
		//private int myVar; -- this is a private variable

		//public int MyProperty { --fully implemented property
		//get { return myVar; } -- private variable is used in this property
		//set { myVar = value; }
		//}

		[Required]
		[StringLength(32)]
		public string Password { get; set; }

		[Required]
		[StringLength(30)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(30)]
		public string LastName { get; set; }

		[Required]
		[StringLength(12)]
		public string Phone { get; set; }

		[Required]
		[StringLength(30)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		public Boolean IsReviewer { get; set; }

		[Required]
		public Boolean IsAdmin { get; set; }

		private int Length { get; }
	}
}
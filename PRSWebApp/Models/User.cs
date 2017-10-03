using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PRSWebApp.Models {
	public class User {

		public int UserID { get; set; }

		[Required]
		[StringLength(30)]
		//requires username to be unique
		[Index(IsUnique = true)]
		public string UserName { get; set; }

		[Required]
		[StringLength(16)]
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
	}
}
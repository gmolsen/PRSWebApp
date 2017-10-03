$().ready (function() {

$("#call").click(function() {


		/* ajax call is made to "List()" inside UsersController 
		which then returns an array containing all properties for
		each user (JSON) */ 
		$.getJSON(
			"http://localhost:65241/Users/List/",
			function(Users) {
			//jQuery command that clears content of table
 			$("tbody").empty();
 			// JSON user data is then printed as HTML in table format
 			for(var user of Users) {
 			var row = "<tr>" + "<td>" + user.UserName + "</td>";
 			row += "<td>" + user.Email + "</td>";
			row += "</tr>";
			/* jQuery command that appends formatted data into text of tag
			containing id "tbody" in this case it is the body of a table*/ 
				$("#tbody").append(row);
			};
			
		});
	});
});

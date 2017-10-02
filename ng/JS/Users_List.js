$().ready (function() {

$("#call").click(function() {


		*/ ajax call is made to "List()" inside UsersController 
		which then returns an array containing all properties for
		each user (JSON)*/ 
		$.getJSON(
			"http://localhost:65241/Users/List/",
			function(user) {
			//jQuery command that clears content of table
 			$("tbody").empty();
 			// JSON user data is then printed as HTML in table format
 			for(var users of Users) {
 			var row = "<tr>" + "<td>" + users.UserName + "</td>";
 			row += "<td>" + users.Email + "</td>";
			row += "</tr>";
			/* jQuery command that appends formatted data into text of tag
			containing id "tbody" in this case it is the body of a table*/ 
				$("#tbody").append(row);
			};
			
		});
	});
});

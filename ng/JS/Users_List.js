$().ready (function() {

$("#call").click(function() {

		$.getJSON(
			"http://localhost:65241/Users/List/",
			function(user) {
 			$("tbody").empty();
 			for(var users of Users) {
 			var row = "<tr>" + "<td>" + users.UserName + "</td>";
 			row += "<td>" + users.Email + "</td>";
			row += "</tr>";
				$("#tbody").append(row);
			};
			
		});
	});
});

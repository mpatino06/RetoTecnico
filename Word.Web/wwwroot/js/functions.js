function GetValidateWords() {

	debugger;

	var textToEvaluate = $("#wordsToEvaluate").val().trim();
	if (textToEvaluate.length == 0) {
		alert("Debe Ingresar una palabra para realizar la validación")

	} else {

		$.ajax({
			type: "POST",
			url: "/Home/ValidateCountWords",
			data: { texto: textToEvaluate },
			cache: false
		}).done(function (data) {
			debugger;

			if (data.length > 0) {

				var divLi = document.getElementById("divLiWords");
				$(divLi).show();

				var ul = document.getElementById("friendsList");

				for (var i = 0; i < data.length; i++) {
					var name = data[i];
					var li = document.createElement('li');
					li.appendChild(document.createTextNode(name.word + ': ' + name.countWord));
					ul.appendChild(li);
				}
			} else {
				alert("No existen palabras Repetidas...!")
			}

		}).fail(function (data) {

		}).always(function () {

		});

	}

};

function CleanControls() {
	$('#formCountWords').each(function () {
		this.reset();
	});

	var root = document.getElementById("friendsList");
    var divLi = document.getElementById("divLiWords");
	
	$(root).empty();
	$(divLi).hide();
}
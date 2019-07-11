function getResults() {
    let req = new XMLHttpRequest();
    let react = document.getElementById("react").value
	let url = `http://localhost:50056/api/Ingredients/GetMainIngredients/${react}`
	req.open('GET', url)
	req.onload = function () {
        var resp = JSON.parse(req.response)
        if (req.status != 200)
        {
            document.getElementById("results").innerHTML = resp
            return
        }
        console.log(req.status)
        console.log(resp)
        console.log(resp.results.length)
        console.log(req.reponse)
        tableStr = "<table border='1' style='text-align: center' cellpadding='5'><tr><th>TERM</th><th>COUNT</th></tr><tr>";
		for (let i = 0; i < resp.results.length; i++) {
            
            var item = resp.results[i];
            tableStr += `<tr><td>${item.Term}</td><td>${item.Count}</td></tr>`
        }
        tableStr += "</table>"
        document.getElementById("results").innerHTML = tableStr;
	}
	req.onerror = function () {
		alert('error')
	}
	req.send()
}


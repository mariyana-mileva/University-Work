const btn = document.querySelector("button");




function getAfact(){
    let input = document.querySelector("input").value;
    let facts = document.getElementById("facts");

    fetch(`http://numbersapi.com/${input}`)
    .then((response) => response.text())
    .then((data) => {
        facts.style.opacity = "1";
        facts.innerHTML = data;
    })
}
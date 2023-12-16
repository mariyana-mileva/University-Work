document.getElementById("close-button").addEventListener("click", () => {
  document.getElementById("country-details").style.display = "none";
});
document.querySelectorAll(".path").forEach((e) => {
  e.addEventListener("click", () => {
    fetch("languages.json")
      .then((response) => response.json())
      .then((data) => getLanguage(data));

      function getLanguage(data){
        console.log(data)
        data.forEach(element => {
            if(element.name == e.id){
                document.getElementById("country-language").innerText = "Language: "+element.language;
                document.getElementById("flag").src = element.flag;
            }
        });
    }

    document.getElementById("country-details").style.display = "flex";
    document.getElementById("country-name").innerText = e.id;
  });
});


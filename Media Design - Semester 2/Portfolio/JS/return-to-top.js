const button = document.getElementById("topButton");




button.addEventListener("click", topFunction);




// When the user clicks on the button, scroll to the top of the document
function topFunction() {
  document.body.scrollTop = 0;
  document.documentElement.scrollTop = 0;
}
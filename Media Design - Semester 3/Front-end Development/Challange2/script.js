// Get the "play-again" and "toggleColorButton" elements by their IDs
const playAgain = document.getElementById("play-again");
const toggleColors = document.getElementById("toggleColorButton");

// Add a click event listener to the "play-again" button to reload the page when clicked

playAgain.addEventListener("click", () => {
  // Reload the current page
  location.reload();
});

// Add a click event listener to the "toggleColorButton" button to toggle color inversionP
toggleColors.addEventListener("click", toggleColorInversion);

// Define the toggleColorInversion function
function toggleColorInversion() {
  const body = document.getElementById("body"); // You can change the selector if you want to apply it to a different element

  // Check if the "inverted" class is currently applied to the "body" element
  const isInverted = body.classList.contains("inverted");

  // If the colors are inverted
  if (isInverted) {
    body.classList.remove("inverted"); // Remove the "inverted" class
    body.style.backgroundColor = "rgb(255, 255, 255)";
  } else {
    // If the colors are not inverted
    body.classList.add("inverted"); // Add the "inverted" class
    body.style.backgroundColor = "rgb(0, 0, 0)";
  }
}



//                                    CLASS DECLARATION
//####################################################################################
class Player {
  constructor(name, age, occupation, countryOfResidence) {
    this.name = name;
    this.age = age;
    this.occupation = occupation;
    this.countryOfResidence = countryOfResidence;
  }

  lives = 4; // Initialize player lives to 4
}

//                                      VARIABLES
//####################################################################################
const countrySelect = document.getElementById("country"); // Get a reference to the HTML element with id "country"
const infoBtn = document.getElementById("info-button"); // Get a reference to the HTML element with id "info-button"
const backBtn = document.getElementById("back-button"); // Get a reference to the HTML element with id "back-button"
const startBtn = document.getElementById("start-button"); // Get a reference to the HTML element with id "start-button"
const addPlayerForm = document.getElementById("add-player"); // Get a reference to the HTML element with id "add-player"
const addPlayerBtn = document.getElementById("add-player-btn"); // Get a reference to the HTML element with id "add-player-btn"
const startMenu = document.getElementById("start-menu"); // Get a reference to the HTML element with id "start-menu"
const startOver = document.getElementById("start-over-button"); // Get a reference to the HTML element with id "start-over-button"

var isGameOn = false; // Initialize a variable to track if the game is on or not
const players = []; // Initialize an array to store player objects

// Fetching country data from an API
fetch("https://restcountries.com/v3.1/all")
  .then((response) => response.json()) // Parse the response as JSON
  .then((data) => {
    data.forEach((country) => {
      const option = document.createElement("option"); // Create an HTML <option> element
      option.value = country.name.common; // Set the value attribute of the <option> element
      option.textContent = country.name.common; // Set the text content of the <option> element
      countrySelect.appendChild(option); // Append the <option> element to the "countrySelect" element
    });
  })
  .catch((error) => {
    console.error("Error fetching data: " + error); // Log an error if there's an issue fetching data
  });

//                                   FUNCTIONS
//####################################################################################

// Function to create a player and add it to the players array
function createPlayer(name, age, occupation, countryOfResidence) {
  const player = new Player(name, age, occupation, countryOfResidence); // Create a new Player object with the given name
  players.push(player); // Add the player to the players array
}

// Function to handle a game round, returning true if the guess is correct
function gameRound(playerGuess, number) {
  if (playerGuess == number) {
    return true; // Guessed correctly
  } else {
    return false; // Guessed incorrectly
  }
}

// Function to handle the game logic
function gameOn(player1, player2) {
  const player1Name = document.getElementById("player-1-name"); // Get a reference to the HTML element with id "player-1-name"
  const player2Name = document.getElementById("player-2-name"); // Get a reference to the HTML element with id "player-2-name"
  const player1Lives = document.getElementById("player-1-lives"); // Get a reference to the HTML element with id "player-1-lives"
  const player2Lives = document.getElementById("player-2-lives"); // Get a reference to the HTML element with id "player-2-lives"
  const player1Occupation = document.getElementById("playerOccupation"); // Get a reference to the HTML element with id "player-2-lives"
  const player2Occupation = document.getElementById("playerOccupationPlayer2"); // Get a reference to the HTML element with id "player-2-lives"
  const player1CountryOfRes = document.getElementById("countryOfRes"); // Get a reference to the HTML element with id "player-2-lives"
  const player2CountryOfRes = document.getElementById("countryOfResPlayer2"); // Get a reference to the HTML element with id "player-2-lives"
  const guessButtonPlayer1 = document.getElementById("player1-guess-btn"); // Get a reference to the HTML element with id "player1-guess-btn"
  const guessButtonPlayer2 = document.getElementById("player2-guess-btn"); // Get a reference to the HTML element with id "player2-guess-btn"
  const resultText = document.getElementById("result-text"); // Get a reference to the HTML element with id "result-text"

  player1Name.textContent = `${player1.name} (${player1.age})`; // Set the text content of "player-1-name" to player1's name
  player2Name.textContent = `${player2.name} (${player2.age})`; // Set the text content of "player-2-name" to player2's name
  player1Lives.textContent = player1.lives; // Set the text content of "player-1-lives" to player1's lives
  player2Lives.textContent = player2.lives; // Set the text content of "player-2-lives" to player2's lives
  player1Occupation.textContent = player1.occupation;
  player2Occupation.textContent = player2.occupation;
  player1CountryOfRes.textContent = player1.countryOfResidence;
  player2CountryOfRes.textContent = player2.countryOfResidence;

  let number = Math.floor(Math.random() * 100) + 1;
  console.log(number);

  guessButtonPlayer1.addEventListener("click", () => {
    // Add a click event listener to "player1-guess-btn"
    if (!isGameOn) return; // Return early if the game is over
    const guessPlayer1 = document.getElementById("player-1-guess").value; // Get the value of the input with id "player-1-guess"
    const guessedCorrectly = gameRound(guessPlayer1, number); // Check if the guess is correct
    if (guessedCorrectly) {
      // If guessed correctly
      resultText.textContent = `${player1.name} guessed correctly!`; // Set the result text
      isGameOn = false; // Mark the game as over
      startOver.style.display = "flex"; // Display the "start-over-button"
    } else {
      // If guessed incorrectly
      player1Lives.textContent = --player1.lives; // Decrement player1's lives and update the display
      if (player1.lives === 0) {
        // If player1 runs out of lives
        resultText.textContent = `${player2.name} won!`; // Set the result text
        isGameOn = false; // Mark the game as over
        startOver.style.display = "flex"; // Display the "start-over-button"
      }
    }
  });

  // (Similar code for guessButtonPlayer2 omitted for brevity)
  guessButtonPlayer2.addEventListener("click", () => {
    if (!isGameOn) return; // Game is over
    const guessPlayer2 = document.getElementById("player-2-guess").value;
    const guessedCorrectly = gameRound(guessPlayer2, number);
    if (guessedCorrectly) {
      resultText.textContent = `${player2.name} guessed correctly!`;
      isGameOn = false;
      startOver.style.display = "flex";
    } else {
      player2Lives.textContent = --player2.lives;
      if (player2.lives === 0) {
        resultText.textContent = `${player1.name} won!`;
        isGameOn = false;
        startOver.style.display = "flex";
      }
    }
  });
}

//                                   EVENT LISTENERS
//####################################################################################

// Event listener for the "Info" button
infoBtn.addEventListener("click", () => {
  // Add a click event listener to "info-button"
  const infoMenu = document.getElementById("info"); // Get a reference to the HTML element with id "info"
  startMenu.style.display = "none"; // Hide the start menu
  infoMenu.style.display = "flex"; // Display the info menu
});

// (Event listeners for "backBtn" and "startBtn" are similar)
backBtn.addEventListener("click", () => {
  const infoMenu = document.getElementById("info");

  startMenu.style.display = "flex";
  infoMenu.style.display = "none";
});

startBtn.addEventListener("click", () => {
  startMenu.style.display = "none";
  addPlayerForm.style.display = "flex";
});

var whichPlayer = 1;

// Event listener for the "Add Player" button
addPlayerBtn.addEventListener("click", () => {
  // Add a click event listener to "add-player-btn"
  const playerNumber = document.getElementById("player-number"); // Get a reference to the HTML element with id "player-number"
  const playerName = document.getElementById("name"); // Get a reference to the HTML element with id "name"
  const playerAge = document.getElementById("age"); // Get a reference to the HTML element with id "age"
  const playerOccupation = document.getElementById("occupation"); // Get a reference to the HTML element with id "occupation"
  const playerCountryOfResidence = document.getElementById("country"); // Get a reference to the HTML element with id "country"

  createPlayer(
    // Create a player with the provided information
    playerName.value, // Get the value of the "name" input
    playerAge.value, // Get the value of the "age" input
    playerOccupation.value, // Get the value of the "occupation" input
    playerCountryOfResidence.value // Get the value of the "country" input
  );

  if (whichPlayer == 1) {
    // If it's the first player
    playerNumber.innerHTML = "Add Player 2"; // Update the player number display
    window.alert("Player 1 added successfully"); // Show an alert indicating player 1 was added
    whichPlayer += 1; // Increment whichPlayer to add the second player next
  } else if (whichPlayer == 2) {
    // If it's the second player
    const gameUi = document.getElementById("game-ui"); // Get a reference to the HTML element with id "game-ui"
    window.alert("Player 2 added successfully"); // Show an alert indicating player 2 was added
    isGameOn = true; // Mark the game as on
    addPlayerForm.style.display = "none"; // Hide the "add-player" form
    gameUi.style.display = "flex"; // Display the game UI

    console.log(players[0].occupation);
    gameOn(players[0], players[1]); // Start the game with player 1 and player 2
  }
});

// Event listener for the "Start Over" button
startOver.addEventListener("click", () => {
  // Add a click event listener to "start-over-button"
  location.reload(); // Reload the page to start over
  gameUi.style.display = "none"; // Hide the game UI
  startMenu.style.display = "flex"; // Display the start menu
});

const express = require("express");
const app = express();

app.get("/", (req, res) => {
  res.send("Welcome to the Home Page!");
});

app.listen(3000, () => {
  console.log("Server is running on http://localhost:3000");
});

app.get("/about", (req, res) => {
  res.sendFile(__dirname + "/about.html");
});

app.get("/contact", (req, res) => {
  res.sendFile(__dirname + "/contact.html");
});

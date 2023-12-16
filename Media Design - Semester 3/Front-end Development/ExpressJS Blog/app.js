const express = require("express");
const app = express();
const basicAuth = require("express-basic-auth");
const blogRoutes = require("./routes/blogRoutes"); // Ensure this path is correct
const db = require("./database"); // Ensure this path is correct to your database setup file

const users = {};
users[process.env.AUTH_USERNAME || "admin"] = process.env.AUTH_PASSWORD || "supersecret";

const auth = basicAuth({
  users,
  challenge: true,
  unauthorizedResponse: "Unauthorized Access!",
});

const router = express.Router();

app.set("view engine", "ejs");
app.use(express.urlencoded({ extended: true })); // Body parser for form data

app.use(express.static("public"));

app.use('/blogs', auth, blogRoutes);


// Routes
app.get("/", (req, res) => res.redirect("/blogs")); // Redirect root to the blogs
app.use("/blogs", blogRoutes);

// Database initialization (optional here if you have it in your database.js but in our example we have it so you can leave this as a comment)
// db.run("CREATE TABLE IF NOT EXISTS posts (id INTEGER PRIMARY KEY AUTOINCREMENT, title TEXT, content TEXT, created_at DATETIME DEFAULT CURRENT_TIMESTAMP)");

const PORT = process.env.PORT || 3000;
app.listen(PORT, () => console.log(`Server running on port ${PORT}`));

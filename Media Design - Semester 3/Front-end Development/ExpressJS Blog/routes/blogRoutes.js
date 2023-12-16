const express = require("express");
const router = express.Router();
const db = require("../database");

// Route to display all blog posts
router.get("/", (req, res) => {
  const sortOrder = req.query.sortOrder === "asc" ? "ASC" : "DESC";

  const query = `SELECT * FROM posts ORDER BY created_at ${sortOrder}`;

  db.all(query, [], (err, rows) => {
    if (err) {
      throw err;
    }
    res.render("index", { posts: rows });
  });
});

// Route to display the form for a new blog post
router.get("/new", (req, res) => {
  res.render("new");
});

// Route to add a new blog post
router.post("/", (req, res) => {
  const { title, content } = req.body;
  db.run(
    "INSERT INTO posts (title, content) VALUES (?, ?)",
    [title, content],
    (err) => {
      if (err) {
        throw err;
      }
      res.redirect("/blogs");
    }
  );
});

router.get("/sort", (req, res) => {
  const sortOrder = req.query.sortOrder === "asc" ? "asc" : "desc";

  // Use the correct sortOrder in the query
  const query = `SELECT * FROM posts ORDER BY created_at ${sortOrder}`;

  db.all(query, [], (err, rows) => {
    if (err) {
      throw err;
    }
    res.render('index', { posts: rows, sortOrder: sortOrder });  // Pass sortOrder to the template
  });
});
module.exports = router;

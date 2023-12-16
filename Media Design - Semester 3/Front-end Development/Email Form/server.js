const express = require("express");
const app = express();
const nodemailer = require("nodemailer");
const bodyParser = require("body-parser");
const multer = require("multer");
const path = require("path");

app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());
app.use(express.static(__dirname));

const transporter = nodemailer.createTransport({
  host: "localhost",
  port: 1025,
  auth: {
    user: "project.1",
    pass: "secret.1",
  },
});

const uploadDirectory = path.join(__dirname, "uploads"); 

const storage = multer.diskStorage({
  destination: (req, file, cb) => {
    cb(null, uploadDirectory);
  },
  filename: (req, file, cb) => {
    const ext = path.extname(file.originalname);
    cb(null, Date.now() + ext);
  },
});

const upload = multer({ storage });

app.get("/", (req, res) => {
  res.sendFile(__dirname + "/form.html");
});

app.post("/send-email", upload.single("attachment"), (req, res) => {
  const { name, email, subject, message } = req.body;
  const attachment = req.file;
  let emailContent = `<body style="background-color: #f5f5f5; margin: 0; padding: 0;">`;
  emailContent += `<div class="container" style="max-width: 600px; margin: 0 auto; background-color: #fff; padding: 20px; border-radius: 10px; box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1);">`;
  emailContent += `<div class="header" style="background-color: #0073e6; color: #fff; padding: 10px; text-align: center; border-top-left-radius: 10px; border-top-right-radius: 10px;">`;
  emailContent += `<h1 style="font-size: 24px; margin: 20px 0;">Lorem ipsum dolor sit amet</h1>`;
  emailContent += `</div>`;
  emailContent += `<p style="font-size: 16px; color: #333; margin: 0 auto; margin-top: 20px;">${message}</p>`;
  emailContent += `<p style="font-size: 16px; color: #333; margin: 0 auto; margin-top: 20px;">Send by: ${name}</p>`;

  if (attachment) {
    const publicAttachmentURL = `http://localhost:5000/uploads/${attachment.filename}`;

    emailContent += `<p style="font-size: 16px; color: #333; margin: 0 auto; margin-top: 20px;">`;
    emailContent += `<a href="${publicAttachmentURL}" target="_blank">View Attachment</a>`;
    emailContent += `</p>`;
  }

  emailContent += `</div>`;
  emailContent += `</body>`;

  const mailOptions = {
    from: email,
    to: "recipient@example.com",
    subject: subject,
    html: emailContent,
  };

  transporter.sendMail(mailOptions, (error, info) => {
    if (error) {
      console.error("Error sending email:", error);
    } else {
      console.log("Email sent:", info.response);
      res.send("Email sent successfully");
    }
  });
  console.log("Uploaded File:", req.file);
});

app.listen(5000, () => {
  console.log("Server is running on http://localhost:5000");
});
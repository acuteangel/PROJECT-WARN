const mongoose = require("mongoose");
const db = require("../models");

mongoose.connect(
  process.env.MONGODB_URI ||
  "mongodb://localhost/WARNleaderboard"
);

const scoreSeed = [
  {
    name: "Raj",
    score: "2",
    date: new Date(Date.now())
  },
  {
    name: "Will",
    score: "2",
    date: new Date(Date.now())
  },
  {
    name: "Angel",
    score: "1",
    date: new Date(Date.now())
  },
  {
    name: "Nick",
    score: "1",
    date: new Date(Date.now())
  }
];

db.leaderboard
  .remove({})
  .then(() => db.leaderboard.collection.insertMany(scoreSeed))
  .then(data => {
    console.log(data.result.n + " records inserted!");
    process.exit(0);
  })
  .catch(err => {
    console.error(err);
    process.exit(1);
  });

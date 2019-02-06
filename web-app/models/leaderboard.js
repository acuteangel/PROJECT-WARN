const mongoose = require("mongoose");
const Schema = mongoose.Schema;

const scoreSchema = new Schema({
  name: { type: String, required: true },
  score: { type: String, required: true },
  date: { type: Date, default: Date.now }
});

const leaderboard = mongoose.model("leaderboard", scoreSchema);

module.exports = leaderboard;

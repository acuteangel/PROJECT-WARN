const mongoose = require("mongoose");
const Schema = mongoose.Schema;

const scoreSchema = new Schema({
  player: { type: String, required: true },
  score: { type: String, required: true },
});

const Scores = mongoose.model("Scores", scoreSchema);

module.exports = Scores;

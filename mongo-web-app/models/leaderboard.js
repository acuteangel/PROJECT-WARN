const mongoose = require("mongoose");
const Schema = mongoose.Schema;

const scoreSchema = new Schema({
  player: { type: String, required: true },
  score: { type: Number, required: true },
 // date: { type:  Date, default: Date.now}
});

const Scores = mongoose.model("Scores", scoreSchema);

module.exports = Scores;

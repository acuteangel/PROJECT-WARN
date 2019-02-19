import axios from "axios";

export default {
  getScores: function() {
    return axios.get("/api/leaderboard");
  },

  postScores: function(scoreData) {
    return axios.post("/api/leaderboard", scoreData)
  }

};


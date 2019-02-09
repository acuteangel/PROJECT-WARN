import axios from "axios";

export default {
  getScores: function() {
    return axios.get("/api/leaderboard");
  },
  getScore: function(id) {
    return axios.get("/api/leaderboard/" + id);
  },

};

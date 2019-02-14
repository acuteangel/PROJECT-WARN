import axios from "axios";

export default {
  getScores: function() {
    return axios.get("/api/leaderboard");
  },
  // getScore: function(id) {
  //   return axios.get("/api/leaderboard/" + id);
  // },

  postScores: function(Scores) {
    return axios.post("/api/leaderboard/post", Scores)
  }

};


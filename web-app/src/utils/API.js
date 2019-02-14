import axios from "axios";

export default {
  getScores: function() {
    return axios.get("/api/leaderboard");
  },
  // getScore: function(id) {
  //   return axios.get("/api/leaderboard/" + id);
  // },

  postScores: function() {
    return axios.post("/api/post")
  }

};


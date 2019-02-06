import axios from "axios";

export default {
  // Gets all books
  getScores: function() {
    return axios.get("/api/leaderboard");
  },
  // Gets the book with the given id
  getScores: function(id) {
    return axios.get("/api/leaderboard/" + id);
  },
//   // Deletes the book with the given id
//   deleteBook: function(id) {
//     return axios.delete("/api/books/" + id);
//   },
//   // Saves a book to the database
//   saveBook: function(bookData) {
//     return axios.post("/api/books", bookData);
//   }
};

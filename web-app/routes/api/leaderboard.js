const router = require("express").Router();
const scoresController = require("../../controllers/highscoresController");
const postController = required("../..controllers/posthighscoresController");

router.route("/api/leaderboard")
  .get(scoresController.findAll);

router.route("/api/post")
  .post(postController.create);

module.exports = router;

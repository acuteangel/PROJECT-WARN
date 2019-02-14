const router = require("express").Router();
const scoresController = require("../../controllers/highscoresController");
const postController = require("../../controllers/posthighscoresController");

router.route("/")
  .get(scoresController.findAll)
  .post(scoresController.create);

router.route("/post")
//.post(postController.create);
.post(postController.postScores);

module.exports = router;

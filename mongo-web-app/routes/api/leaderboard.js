const router = require("express").Router();
const scoresController = require("../../controllers/highscoresController");

router.route("/")
  .get(scoresController.findAll)
  .post(scoresController.create);

module.exports = router;

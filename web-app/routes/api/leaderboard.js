const router = require("express").Router();
const scoresController = require("../../controllers/highscoresController");

router.route("/")
  .get(scoresController.findAll)
  .post(scoresController.create);

// router
// .route("/:id")
// .get(booksController.findById)
// .put(booksController.update)
// .delete(booksController.remove);

module.exports = router;

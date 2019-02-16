var db = require("../models");

exports.getScores = function (req, res) {
  db.Scores.findAll({
    where: {
      scores: req.body.scores, DESC
    }
  
  }).then(() => {
    db.Scores.update({
      player: req.body.player,
      score: req.body.score,

    }).then(() => {
      info.save();
    }).catch(err => {
      res.json(err);
    }).finally(() => {
      db.sequelize.close();
    });

  })

};
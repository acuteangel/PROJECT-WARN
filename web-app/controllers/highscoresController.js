var db = require("../models");

exports.createScores = function (req, res) {
  db.Scores.findAll({
    where: {
      scores: req.body.scores, DESC
    }
  }).then(() => {
    db.Scores.create({
      name: req.body.name,
      score: req.body.score,
      date: req.body.date,

    }).then(() => {
      info.save();
    }).catch(err => {
      res.json(err);
    }).finally(() => {
      db.sequelize.close();
    });

  })
};
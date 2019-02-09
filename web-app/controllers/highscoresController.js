var db = require("../models");

exports.createScores = function (req, res) {
  db.Scores.findAll({
    where: {
      scores: req.body.scores, DESC
    }
  }).then(function () {
    db.Scores.create({
      name: req.body.name,
      score: req.body.score,
      date: req.body.date,

    }).then(function () {
      info.save();
    }).catch(function(err) {
      res.json(err);
    }).finally(function () {
      db.sequelize.close();
    });

  })
};
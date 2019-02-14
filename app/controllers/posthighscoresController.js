var db = require("../models");


exports.postScores = function (req, res) {
    db.Scores.create({
      player: req.body.player,
      score: req.body.score,  

    }).then(() => {
      info.save();
    }).catch(err => {
      res.json(err);
    }).finally(() => {
      db.sequelize.close();
    });

    // db.Scores.create(req.body).then(function(dbPost) {
    //   res.json(dbPost);
    // });
};
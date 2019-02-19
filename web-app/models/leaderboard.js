module.exports = function(sequelize, DataTypes) {
  var Scores = sequelize.define("highscores", {
    player: {
      type: DataTypes.STRING,
      allowNull: false,
      validate: {
        len: [1, 20]
      }
    },
    score: {
      type: DataTypes.STRING,
      allowNull: false,
 //     defaultValue: false
    },
    // date: {
    //   createdAt: Sequelize.DATE,
    //   defaultValue: false
    // }
  });
  return Scores;
};


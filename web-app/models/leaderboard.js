module.exports = function(sequelize, DataTypes) {
  var Scores = sequelize.define("scores", {
    name: {
      type: DataTypes.STRING,
      allowNull: false,
      validate: {
        len: [1, 20]
      }
    },
    score: {
      type: DataTypes.INTEGER,
      defaultValue: false
    },
    date: {
      createdAt: Sequelize.DATE,
      defaultValue: false
    }
  });
  return Scores;
};


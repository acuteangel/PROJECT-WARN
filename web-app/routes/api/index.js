const router = require("express").Router();
const leaderRoutes = require("./leaderboard");

router.use("/", leaderRoutes);

module.exports = router;

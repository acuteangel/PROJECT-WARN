const router = require("express").Router();
const leaderRoutes = require("./leaderboard");

router.use("/leaderboard", leaderRoutes);

module.exports = router;

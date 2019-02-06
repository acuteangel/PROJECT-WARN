import React from "react";
import leaderboard from "./pages/leaderboard";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import about from "./pages/about";
import NoMatch from "./pages/NoMatch";
import Nav from "./components/Nav";

function App() {
  return (
    <Router>
    <div>
      <Nav />
      <Switch>
        <Route exact path="/" component={leaderboard}/>
        <Route exact path="/about" component={about}/>
        <Route exact path="/contact" component={contact} />
        <Route component={NoMatch} />
      </Switch>
    </div>
    </Router>

  );
}

export default App;

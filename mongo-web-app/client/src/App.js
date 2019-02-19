import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import Leaderboard from "./pages/Leaderboard";
import About from "./pages/About";
import NoMatch from "./pages/NoMatch";
import Nav from "./components/Nav";
import Contact from "./pages/Contact"

function App() {
  return (
    <Router>
    <div>
      <Nav />
      <Switch>
        <Route exact path="/" component={Leaderboard}/>
        <Route exact path="/about" component={About}/>
        <Route exact path="/contacts" component={Contact} />
        <Route component={NoMatch} />
      </Switch>
    </div>
    </Router>

  );
}

export default App;

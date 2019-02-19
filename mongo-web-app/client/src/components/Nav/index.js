import React from "react";
import "./style.css";

function Nav() {
  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-primary">
      <a className="navbar-brand" href="/">
        Leaderboard
      </a>
      <a className="navbar-brand" href="/about">
        About Game
      </a>
      <a className="navbar-brand" href="/contacts">
        Contacts
      </a>
      <h3 >
      W.A.R.N. Web App
      </h3>
    </nav>
  );
}

export default Nav;

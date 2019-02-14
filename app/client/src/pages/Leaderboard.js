import React, { Component } from "react";
import Jumbotron from "../components/Jumbotron";
import API from "../utils/API";
import { Col, Row, Container } from "../components/Grid";
import { List, ListItem } from "../components/List";

class leaderboard extends Component {
  state = {
    boards: [],
    name: "",
    score: "",
   // date: ""
  };

  componentDidMount() {
    this.loadScores();
  }

  loadScores = () => {
    API.getScores()
      .then(res =>
        // this.setState({ boards: res.data, name: "", score: "" })//, date: ""})
        console.log("Hey ya'll")
      )
      .catch(err => console.log(err));
  };

  handleFormSubmit = event => {
    event.preventDefault();
    if (this.state.player && this.state.score) {
      API.postScores({
        player: this.state.player,
        score: this.state.score,
      })
        .then(res => this.loadScores())
        .catch(err => console.log(err));
    }
  };
  
  render() {
    return (
      <Container fluid>
        <Row>
          <Col size="md-12">
            <Jumbotron>
              <h1>High Scores!</h1>
            </Jumbotron>
            {this.state.boards.length ? (
              <List>
                {this.state.boards.map(board => (
                  <ListItem key={board._id}>
                      <strong>
                        {board.name} || {board.score} || 
                      </strong>
                  </ListItem>
                ))}
              </List>
            ) : (
              <h3>No Results to Display</h3>
            )}
          </Col>
        </Row>
      </Container>
    );
  }
}

export default leaderboard;

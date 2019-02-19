import React, { Component } from "react";
import Jumbotron from "../components/Jumbotron";
import API from "../utils/API";
import { Col, Row, Container } from "../components/Grid";
import { List, ListItem } from "../components/List";

//import Moment from "react-moment"
//import { TimeDate } from "../components/React-Moment/react-moment";




class Leaderboard extends Component {
  state = {
    scores: [],
    player: "",
    score: "",
    date: ""
  };

  componentDidMount() {
    this.loadScores();
  }

  loadScores = () => {
    API.getScores()
      .then(res =>
       this.setState({ scores: res.data, player: "", score: "", date: "" })
       // console.log("why no load")
      )
      .catch(err => console.log(err));
     // window.location.reload();
  };

  render() {
    return (
      <Container fluid>
        <Row>
          <Col size="sm-12">
            <Jumbotron>
              <h1>High Scores Leaderboard!!!</h1>
              
              <h3>Player || Score</h3>
              
            </Jumbotron>
            </Col>
            </Row>
            <Row>
            <Col size="sm-12">
            {this.state.scores.length ? (
              <List>
                
                

                {this.state.scores.map(board => (
                  <ListItem key={board.score}>
                      <strong>
                        {board.player} || {board.score}  {/*<TimeDate>{board.date}</TimeDate> {board.date} */}
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

export default Leaderboard;

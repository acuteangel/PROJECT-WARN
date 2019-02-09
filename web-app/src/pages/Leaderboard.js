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
  };

  componentDidMount() {
    this.loadScores();
  }

  loadScores = () => {
    API.getScores()
      .then(res =>
        this.setState({ boards: res.data, name: "", score: ""})
      )
      .catch(err => console.log(err));
  };

//   deleteBook = id => {
//     API.deleteBook(id)
//       .then(res => this.loadBooks())
//       .catch(err => console.log(err));
//   };

//   handleInputChange = event => {
//     const { name, value } = event.target;
//     this.setState({
//       [name]: value
//     });
//   };

//   handleFormSubmit = event => {
//     event.preventDefault();
//     if (this.state.title && this.state.author) {
//       API.saveBook({
//         title: this.state.title,
//         author: this.state.author,
//         synopsis: this.state.synopsis
//       })
//         .then(res => this.loadBooks())
//         .catch(err => console.log(err));
//     }
//   };

  render() {
    return (
      <Container fluid>
        <Row>
          <Col size="md-6 sm-12">
            <Jumbotron>
              <h1>High Scores!</h1>
            </Jumbotron>
            {this.state.boards.length ? (
              <List>
                {this.state.boards.map(board => (
                  <ListItem key={board._id}>
                      <strong>
                        {board.name} || {board.score}
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

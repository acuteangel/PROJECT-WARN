import React, { Component } from "react";
import Jumbotron from "../components/Jumbotron";
import API from "../utils/API";
import { Col, Row, Container } from "../components/Grid";
import { List, ListItem } from "../components/List";

class about extends Component {

  render() {
    return (
      <Container fluid>
        <Row>
          <Col size="md-12">
            <Jumbotron>
              <h1>
              Instructions
              </h1>
            </Jumbotron>
          </Col>
        </Row>
      </Container>
    );
  }
}

export default about;

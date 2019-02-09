import React, { Component } from "react";
import ContactCard from "../components/ContactCard";
import Wrapper from "../components/Wrapper";
import Title from "../components/Title";
import contacts from "../contacts.json";

class Contact extends Component {
  state = {
    contacts
  };

  render() {
    return (
      <Wrapper>
        <Title>Contact Information</Title>
        {this.state.contacts.map(contact => (
          <ContactCard
            id={contact.id}
            key={contact.id}
            name={contact.name}
            image={contact.image}
            about={contact.about}
          />
        ))}
      </Wrapper>
    );
  }
}

export default Contact;
import React from "react";
import "./style.css";

function ContactCard(props) {
  return (
    <div className="card">
      <div className="img-container">
        <img alt={props.name} src={props.image} />
      </div>
      <div className="content">
        <ul>
          <li>
            <strong>Name:</strong> {props.name}
          </li>
          <li>
            <strong>about:</strong> {props.about}
          </li>
        </ul>
      </div>
    </div>
  );
}

export default ContactCard;
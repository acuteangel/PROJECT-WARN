import React from "react";
import { Link } from "react-router-dom";
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
            <Link to={props.about}>
                      <strong>
                        Check out my LinkedIn
                      </strong>
                    </Link>
          </li>
        </ul>
      </div>
    </div>
  );
}

export default ContactCard;
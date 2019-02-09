import React from "react";
import "./style.css";

function ContactCard( children ) {
  return (
    <div className="card">
      <div className="img-container">
        <img alt={ children } src={ children } />
      </div>
      <div className="content">
        <ul>
          <li>
            <strong>Name:</strong> { children }
          </li>
          <li>
            <strong>about:</strong> { children }
          </li>
        </ul>
      </div>
    </div>
  );
}

export default ContactCard;

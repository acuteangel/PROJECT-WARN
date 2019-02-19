import React from "react";
import Moment from "react-moment";

export function TimeDate({ children }) {
  return <Moment date> {children}</Moment>;
}


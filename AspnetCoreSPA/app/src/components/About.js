import React from 'react';
import { connect } from 'react-redux';

const About = props => (
  <div>
    <h5>Introudction</h5>     
    <p> This solution is featured with:</p>
    <ul>
      <li>Frontend: react js + redux + thunk </li>
      <li>Backend: netocre 2.2 + Gembox </li> 
    </ul> </div>
);

export default connect()(About);

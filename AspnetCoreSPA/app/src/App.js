import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import About from './components/About';
import FetchCustomerData from './components/FetchCustomerData';

export default () => (
  <Layout>
    <Route exact path='/' component={FetchCustomerData} />
    <Route path='/about' component={About} />
  </Layout>
);

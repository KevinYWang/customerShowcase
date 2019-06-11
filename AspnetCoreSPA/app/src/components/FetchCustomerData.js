import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../store/customerDataActionsAndReducers';

class FetchCustomerData extends Component {
  componentDidMount() {
    this.ensureDataFetched('');
  }

  // componentDidUpdate() {
  //   // This method is called when the route parameters change
  //   debugger;
  //   this.ensureDataFetched();
  // }

  ensureDataFetched(searchString='') {
    debugger; 
    this.props.requestCustomerData(searchString);
  }

  handleSearchStringInput(event){
    this.ensureDataFetched(event.target.value);
  }

  render() {
    return (
      <div>
        <h1>Contact List</h1>
        <label className="mr-2">Search: </label>
        <input type="text" onChange={this.handleSearchStringInput.bind(this)} /> 
        {renderCustomerDataTable(this.props)}
        {/* {renderPagination(this.props)} */}
      </div>
    );
  }
}

function renderCustomerDataTable(props) {
  return (
    <table className='table table-striped'>
      <thead>
        <tr>
          <th>First Name</th>
          <th>Last Name</th>
          <th>Email</th>
          <th>Phone1</th>
        </tr>
      </thead>
      <tbody>
        {props.customerList.map(customer =>
          <tr key={customer.email}>
            <td>{customer.firstName}</td>
            <td>{customer.lastName}</td>
            <td>{customer.email}</td>
            <td>{customer.phone}</td>
          </tr>
        )}
      </tbody>
    </table>
  );
}

// function renderPagination(props) {
//   const prevStartDateIndex = (props.startDateIndex || 0) - 5;
//   const nextStartDateIndex = (props.startDateIndex || 0) + 5;

//   return <p className='clearfix text-center'>
//     <Link className='btn btn-default pull-left' to={`/fetch-data/${prevStartDateIndex}`}>Previous</Link>
//     <Link className='btn btn-default pull-right' to={`/fetch-data/${nextStartDateIndex}`}>Next</Link>
//     {props.isLoading ? <span>Loading...</span> : []}
//   </p>;
// }

export default connect(
  state => state.customerData,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(FetchCustomerData);

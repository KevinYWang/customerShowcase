import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/customerDataActionsAndReducers';

class FetchCustomerData extends Component {
  componentDidMount() {
    this.ensureDataFetched('');
  }

  ensureDataFetched(searchString = '', pageNumber = 1) {
    this.props.requestCustomerData(searchString, pageNumber);
  }

  handleSearchStringInput(event) {
    this.ensureDataFetched(event.target.value, this.props.pageNumber);
  }

  handlePageChange(pageNumber) {
    this.ensureDataFetched(this.props.searchString, pageNumber);
  }



  render() {
    let pageIds = [];
    for (let i = 1; i <= Math.ceil(this.props.pageTotal / this.props.pageSize); i++) {
      pageIds.push(i);
    }

    return (
      <div>
        <div className="row">
          <h5 className="m-2 mt-1">Contact List</h5>
          <input className="form-control w-50 m-1" type="text" placeholder="Search" aria-label="Search" onChange={this.handleSearchStringInput.bind(this)}></input>
          {renderCustomerDataTable(this.props)}

        </div>

        <p className='clearfix text-center'>
          {pageIds.map(p =>
            <button key={p} type="button"
              className={p === this.props.pageNumber ? 'btn btn-outline-primary pull-left bg-primary text-white m-1' : 'btn btn-outline-primary pull-left m-1'}
              onClick={() => this.handlePageChange(p)}>
              {p}
            </button>)}
          {this.props.isLoading ? <span>Loading...</span> : []}
        </p>

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


export default connect(
  state => state.customerData,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(FetchCustomerData);

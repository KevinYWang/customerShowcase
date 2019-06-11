const requestCustomerDataType = 'Request_CustomerData';
const receiveCustomerDataType = 'Receive_CustomerData';
const initialState = { customerList: [], isLoading: false, searchString: null, pageNumber: 1, pageSize: 15, pageTotal: 0 };

export const actionCreators = {
  requestCustomerData: (searchString, pageNumber) => async (dispatch, getState) => {
    var stateValue = getState().customerData;
    if (searchString === stateValue.searchString && pageNumber === stateValue.pageNumber) {
      return;
    }

    dispatch({
      type: requestCustomerDataType, searchString: searchString, customerList: stateValue.customerList,
      pageNumber: pageNumber, pageSize: stateValue.pageSize, pageTotal: stateValue.pageTotal
    });

    const url = `customer/GetCustomerListBySearchingString?searchString=${searchString}&pageSize=${stateValue.pageSize}&pageNumber=${pageNumber}`;
    const response = await fetch(url);
    let results = await response.json();
    const customerList = results.data;
    const pageTotal = results.total;
    
    dispatch({
      type: receiveCustomerDataType, searchString: searchString, customerList: customerList,
      pageNumber: pageNumber, pageSize: stateValue.pageSize, pageTotal: pageTotal
    });
  }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestCustomerDataType) {
    return {
      ...state,
      searchString: action.searchString,
      customerList: action.customerList,
      isLoading: true
    };
  }

  if (action.type === receiveCustomerDataType) {
    return {
      ...state,
      searchString: action.searchString,
      customerList: action.customerList,
      pageNumber: action.pageNumber,
      pageTotal: action.pageTotal,
      isLoading: false
    };
  }

  return state;
};

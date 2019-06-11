### Development Notes

1. Assumptions: 
	a. frontend: 1) reactjs-redux-thunk is used to craet the SPA; 
				 2) ag-grid is used to show customer list;
	b. backend: gembox is used to read csv into memory, assuming gembox with full license to read the whole file; 
	c. solution structure - four projects: 1) CustomerShowcase.web ; 2) CustomerShowcase.web.tests; 3)CustomerShowcase.common; 4)CustomerShowcase.common.tests; 
	
2. Additional tools or notes made on this exercise:
	a. GemBox is used to reading spreadsheet file data; here  the trial version is used and it only reads 150 rows;
	b. ag-grid is used to render the customer list; 
	
3. Design decisions should also be commented on:
	a. 

4. Additional nice to haves or features that you might suggest but do not have time to complete:
	a. Use Entity Framework to store and possible CRUD operations for the data; 
	b. Front end tests should be added; 



### Summary of breakdown
• Preparation: 1 hour ---  9:00 - 10:00
• Coding: 6 hours (including tests)
	1) backend common and common.tests :  2 hours --- 10:00 - 12:00
	2) backend CustomerController(CustomerShowcase.web) and its testing(CustomerShowcase.web.tests): 0.5 hour--- 12:45 - 13:15
	3) frontend SPA:  4 hours --- 13:15 - 17:15   
• Styling: 1 hour --- 19:00 - 20:00
• Document: 30 minutes --- 20:00 - 20:30

Total: 8.5 hours;

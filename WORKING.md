### Development Notes
1. Assumptions: 
	In the backend part Gembox is used to read csv into memory, assuming Gembox with full license key to read the whole file; 
	

	
2. Additional tools or notes made on this exercise:
	a. GemBox is used to reading spreadsheet file data;But here  the trial version is used and it only reads 150 rows; 
	
	
3. Design decisions should also be commented on:
	a. In general, the solution is structured as SPA (reactjs) + netcore backend;
	b. Frontend:reactjs-redux-thunk is used to create the SPA;
	c. Solution project structure: 
		1) CustomerShowcase.web ; 
		2) CustomerShowcase.web.tests; 
		3) CustomerShowcase.common; 
		4) CustomerShowcase.common.tests; 

4. Additional nice to haves or features that you might suggest but do not have time to complete:
	a. Use Entity Framework to store and possible CRUD operations for the data; 
	b. Front end tests should be added; 
	c. Better styling should be achieved;
	d. PageSize setting can be added; now it uses a default value, 15 rows/page.


### Summary of breakdown
• Preparation: 1 hour ---  9:00 - 10:00
• Coding: 6 hours (including tests)
	1) backend common and common.tests :  2 hours --- 10:00 - 12:00
	2) backend CustomerController(CustomerShowcase.web) and its testing(CustomerShowcase.web.tests): 0.5 hour--- 12:45 - 13:15
	3) frontend SPA:  4 hours --- 13:15 - 17:15   
• Styling: 1 hour --- 19:00 - 20:00
• Document: 30 minutes --- 20:00 - 20:30

Total: 8.5 hours;

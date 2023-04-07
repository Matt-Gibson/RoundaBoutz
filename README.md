# RoundaBoutz

The goal of this project is to develop a Estimate and Customer management system for a small company. This is currently not fully functioning, as some runtime errors exist in the Blazor Component WASM front end. This issue prevents the Update and Delete operations from being completed during a Client side test, as navigation to the pages is being prevented, however all CRUD operations and API endpoints are contained herein. 

The Project does contain over 3 custom classes.
The Project does retrieve Customers from a PostgreSQL DB, store them in a List, and then use the List to populate a table of all Customers via a RazorPage.

3 Requirements

* A List is used when retrieving AllCustomers from the DB.
* The CustomerService calls are async, as they interact with the PostgreSQL DB.
* The "Server" section of the Project is a CRUD API.


In this implementation. The DB component is utilizing a PostgreSQL DB running as a background service, and will need to be installed on the machine looking at the Project.
I have provided an SQL file within the main directory of the repo to fill the DB with 10 example Customers.

For Testing Purposes the DB was set up as follows

"DataBase": "User ID=matthewgibson;Password=12345678;Server=localhost;Port=5432;DataBase=roundboutz; Integrated Security=true;Pooling=true;"
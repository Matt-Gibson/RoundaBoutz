# RoundaBoutz

The goal of this project is to develop a Estimate and Customer management system for a small company. This is currently not fully functioning, as some runtime errors exist in the Blazor Component WASM front end.

The Project does contain over 3 custom classes.
The Project does retrieve Customers from a PostgreSQL DB, store them in a List, and then use the List to populate a table of all Customers via a RazorPage.

3 Requirements

* A List is used when retrieving AllCustomers from the DB.
* The CustomerService calls are async, as they interact with the PostgreSQL DB.
* The "Server" section of the Project is a CRUD API.


The ContactAPI provides a RESTful API to manage contact information.
It supports CRUD operations (Create, Read, Update, Delete) with optional filtering.

Base Route  -   /api/contacts

Endpoints
Get All Contacts		- GET /api/contacts?isActive={true|false}
Get Contact by ID		- GET /api/contacts/{id}
Create a New Contact	- POST /api/contacts
Update an Existing Contact - PUT /api/contacts/{id}
Delete a Contact		- DELETE /api/contacts/{id}


The controller depends on IContactService, which handles the actual business logic.
[ApiController] ensures model binding and automatic 400 Bad Request responses for invalid models.
The API follows REST conventions and uses standard HTTP response codes.


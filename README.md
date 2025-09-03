# .NET 9 Web API – CRUD Operations

The **ContactAPI** provides a RESTful API to manage contact information.  
It supports full **CRUD operations** (Create, Read, Update, Delete) with optional filtering.

---

## 📌 Base Route
/api/contacts

yaml
Copy code

---

## 🔹 Endpoints

| Operation                  | HTTP Method | Route                           | Description                          |
|-----------------------------|-------------|--------------------------------|--------------------------------------|
| Get All Contacts            | GET         | `/api/contacts?isActive={true|false}` | Retrieves all contacts with optional filter |
| Get Contact by ID           | GET         | `/api/contacts/{id}`            | Retrieves a single contact by ID     |
| Create a New Contact        | POST        | `/api/contacts`                 | Creates a new contact                |
| Update an Existing Contact  | PUT         | `/api/contacts/{id}`            | Updates an existing contact          |
| Delete a Contact            | DELETE      | `/api/contacts/{id}`            | Deletes a contact by ID              |

---

## 🔹 Implementation Details

- The controller depends on **`IContactService`**, which handles the business logic.  
- `[ApiController]` ensures:  
  - Automatic **model binding**  
  - Automatic **400 Bad Request** responses for invalid models.  
- The API follows **REST conventions** and uses **standard HTTP response codes**.  

---

## ✅ Example Usage

### Get All Contacts
```http
GET /api/contacts?isActive=true
Create a New Contact
http
Copy code
POST /api/contacts
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@email.com",
  "phone": "1234567890",
  "isActive": true
}
🔹 Technologies Used
.NET 9 – ASP.NET Core Web API

Entity Framework Core – For database operations

In-Memory Collection – For lightweight testing/demo

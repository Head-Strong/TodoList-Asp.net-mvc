### Technical Overview
***

Online Todo list application is created using asp.net mvc. Dotnet framework version 4.6.2 is used. Application code is present in Sample.ToDoList project. <br>

### Architectural Pattern: -
***

Model-View-ViewModel architectural pattern is used. It helps to achieve the separation of concern. ViewModel acts as glue between the model and the view. It helps to convert the model in such a format that is desired by the view. 

### Design Patterns
***

* Repository pattern: - It abstract the data access logic. It helps to separately test the business logic and data access logic.
* Inversion of control: - It is used to decouple the dependencies.

### Authentication
***

Form authentication is used. 

### Unit Testing
***

Nunit, Moq and fluent assertion is used to setup the test project (Sample.ToDoList.Tests). 

### Open Source Libraries
***

* Autofac: IOC container
* AutoMapper: Map models with view models.
* Nunit: Testing framework.
* Moq: Mock external dependencies wile testing specific unit.
* Fluent Assertions: Use to make assertions more beautiful and understandable. 
* Bootstrap: It is used for responsive design.

### Future Enhancements
***

**Functional**
* Completed task should move into different view.
* User should be able to set the priority of the task by drag and drop.
* User should be able to set reminder on a task (email or sms).
* User registration screen.

**Technical**
* Store data in database. Use ORM (Entity framework, dapper etc).
* Implement logging framework (Elmah, serilog etc).
* Write performance test for the application.

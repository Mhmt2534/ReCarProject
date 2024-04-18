<h1>RentalCarProject</h1>
The project was developed in C#, in accordance with the multi-layered architecture and SOLID principles. CRUD operations were performed using the Entity Framework. MSSQL Localdb was used for database in the project. This system includes authentication and authorization. Users can only perform transactions for which they are authorized. Implementations of JWT; Transaction, Cache, Validation and Performance aspects have been implemented. Fluent Validation support for Validation, Autofac support for IoC added. The project includes CRUD operations for car, brand, color, car images, user, operations claim, user operation claims, customer, credit card and rental. Car rental is carried out according to certain business rules. In addition, findeks scores increase according to the users' car rentals. Each car has its own findeks score. The user must have enough Findeks points to rent a car.
<h1>Layers</h1>
Core : The core layer of the project is used for universal operations.<br>
DataAccess : It is the layer that connects the project with the Database.<br>
Entities: Our tables in the database have been created as objects in our project. It also contains DTO objects.<br>
Business : It is the business layer of our project. Various business rules; Data controls, validations and authorization controls<br>
WebAPI : It is the Restful API Layer of the project. Known methods: Get, Post, Put, Delete<br>

<h1>Used Technologies</h1>
Restful API <br>
Result Types<br>
AutoMappers<br>
Interceptor<br>
Autofac<br>
AOP, Aspect Oriented Programming<br>
Caching<br>
Performance<br>
Transaction<br>
Validation<br>
Fluent Validation<br>
Cache Management<br>
JWT Authentication<br>
Repository Design Pattern<br>
Cross Cutting Concerns<br>
Caching<br>
Validation<br>
Extensions<br>
Claim<br>
Exception Middleware<br>
Service Collection<br>
Error Handling<br>
Validation Error Details

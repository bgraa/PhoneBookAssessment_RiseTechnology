# PhoneBookAssessment_RiseTechnology

This project is designed with microservice architecture. There are 3 different projects: API Gateway, Contact API and Report API. Contact API and Report API projects are designed using Repository Pattern and Unit Of Work. These projects are used by making requests to API Gateway.

# Technologies And Database

- .NET 6
- Entity Framework Core
- Code First Migration
- AutoMapper
- Rabbit MQ
- MsTest
- PostgreSQL

# Usage
#### 1. PostgreSQL is required. If PostgreSQL is not installed on your computer, should firstly download and install it. Then you should make the following changes.

#### Step 1 
 - You should edit the `ContactAPIDbConnection` in the `ConnectionStrings` in the `appsettings.json` file in `ContactAPI` according to the PostgreSQL configuration you have installed.

#### Step 2 
 - You should edit the `ReportAPIDbConnection` in the `ConnectionStrings` in the `appsettings.json` file in `ReportAPI` according to the PostgreSQL configuration you have installed. 
 
 

#### 2. RabbitMQ is required. If RabbitMQ is not installed on your computer, should firstly download and install it. Then you should make the following changes.

#### Step 1 
 - You should edit the `RabbitMQ` in the `appsettings.json` file in `ReportAPI` according to the RabbitMQ configuration you have installed.

#### Step 2 
 - You should edit the `RabbitMqConnection` in the `Settings` in the `appsettings.json` file in `ReportAPI` according to the RabbitMQ configuration you have installed.



#### 3. The application is used by sending requests to other services over `APIGateway`. Endpoints are specified in the `ocelotConfig.json` file in the `APIGateway` project. If you want to change you should make the appropriate configuration by changing the required fields in this file.
- `APIGateway` endpoint => `https://localhost:5000`
- For `ContactAPI` => `https://localhost:5000/contact-api/persons`
- For `ReportAPI` => `https://localhost:5000/report-api/reports`

![assessment-diagram drawio](https://user-images.githubusercontent.com/26311692/173963343-10f86f73-4ae8-447b-b044-cc79e2125749.png)


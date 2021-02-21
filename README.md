# Phone Directory Application
---
## Project overview

Although the project seems like a simple application, the queuing system has been used for the report requests of the individuals. For this, the new technology RabbitMQ message queuing technology is used. The services that are processed within the scope of the project are built on the microservice architecture structure. For this reason, the technologies used for the operations performed for the User service do not need to meet with the technologies used for the Report service. Since they are microservices, both separate database applications can be used. Two separate databases are used in this application. Repository design was applied with layered architecture as well as micro service. For this reason, error management will be easier for a change to be made within any service. Since the application is a simple application, monitoring was not performed. Repository design is enough for now to prevent this. Although the test procedures were tried to be passed at the end of the application, the test was not performed due to the limited time.

This application does the following for a person's phone book.

+ Create a contact in the directory
+ Remove a contact in the directory
+ Adding contact information to a contact in the phonebook
+ Removing contact information from a contact
+ Listing contacts in the directory
+ Bringing detailed information about a person in the directory, including contact information
+ A report request that produces statistics of the contacts based on their location
+ Listing the reports generated by the system
+ Bringing the detailed information of a report created by the system

---

## How to download the project

The project can be accessed via Git Hub. You can find the link here. `git clone https://github.com/ugurkaramanoglu/PhoneDirectoryApplication.git`

---

## How to run the Project

Multiple selection is required for the project running part.
For multiple selection, the following projects must be selected and run in order for the whole stream to work properly.

+ PhoneDirectoryApp.APIGateway
+ PhoneDirectoryApp.API
+ PhoneDirectoryApp.ReportAPI
+ PhoneDirectoryApp.Registration
+ PhoneDirectoryApp.UI

---

## Test section

Testing could not be done for this application. In the future, testing can be done upon request.

---

## Technologies used in project development

The following technologies were used while developing the project.

+ CSS
+	Boostrap
+	Jquery
+	Ajax
+	.Net Core
+	.Net Core MVC
+	ApiGateway(ocelot)
+	RabbitMQ
+	PostgreSQL
+	Git

---

## Project developer

Uğur Karamanoğlu - 
BilgeAdam Bilişim Teknoloji Grubu Software Developer


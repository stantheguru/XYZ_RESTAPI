# XYZ API
The project has 4 controllers, i.e, StudentController, FamilyBankPaymentController, XYZPaymentController and NotificationController

# StudentController
It has the following APIS;
1. GET API For selecting all students
2. GET API for selecting a specific student based on StudentID
3. POST API for adding a student record
4. PUT API for updating a student record
5. DELETE API for deleting a student record

# FamilyBankPaymentController
It has the following APIS;
1. GET API For selecting all payments
2. GET API for selecting a specific payment based on PaymentID
3. GET API for selecting a specific payment based on PyamentMethod
4. GET API for selecting a specific payment based on BankChannel
5. POST API for adding a payment record. This API simulates a fee payment procesess ata bank. The payment is fast saved into the Family Bank database and the saved into the XYZ_Payment tabel in the XYZ staging database. Finally, a notification record is added to the Notification table in the XYZ table.The notifcation is then channelled to the Student uisng the Notification Channel saved in the XYZ_Payment table
6. PUT API for updating a payment record
7. DELETE API for deleting a payment record

# XYZPaymentController
It has the following APIS;
1. GET API For selecting all payments
2. GET API for selecting a specific payment based on PaymentID
3. GET API for selecting a specific payment based on PyamentMethod
4. GET API for selecting a specific payment based on BankChannel
5. PUT API for updating a payment record
6. DELETE API for deleting a payment record

# NotificationController
It has the following APIS;
1. GET API For selecting all notifications
2. GET API for selecting a specific notifcations based on NotifcationID
3. PUT API for updating a notification record
4. DELETE API for deleting a notification record

# Using XYZ_REST API
I created the project with Visual Studio 2022
Follow these steps to use the APIS;
1. Install Visual Studio into your PC
2. Install Mysql community server and create database xyz
3. git clone the project into your PC.
4. Click the XYZ.sln file to launch the project
5. Update database settings in the appsettings.json file and DBContext.cs file
6. Select the Start Debugging tool to run the project
7. The Swagger UI will lauch on your web browser and you can test all the APIS


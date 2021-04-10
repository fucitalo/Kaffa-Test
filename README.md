# Kaffa-Test

# About
In the next sections, each exercise will be described and it will be shown how they work.
To facilitate the access to all exercises, a menu was created for selecting the desired exercise, everithing that is not between 1 and 7 will close the program.<br/>
![image](https://user-images.githubusercontent.com/38429356/114234994-e947d180-9955-11eb-9574-336e92958fd2.png)

# Instructions
Once inside the folder containing the files(KaffaTest), only type "dotnet run" to start the program.
>For the exercises 6 and 7, it was needed to install a new package to read the json files, through the command "dotnet add package Newtonsoft.Json"
><br/>PS: To run the command "dotnet" it is necessary to have the SDK for the .NET installed. 

# Exercise 1 - Validate CNPJ format (Mask)
This code will check if the given number is in the format of the CNPJ.
>The accepted formats are: "00.000.000/0000-00" and "00000000000000;
>In this image, it is shown the first format being validated:

>![image](https://user-images.githubusercontent.com/38429356/114228599-0cba4e80-994d-11eb-97e2-fecb263e2ab7.png)

>In this other image, the same is being done for the second format:

>![image](https://user-images.githubusercontent.com/38429356/114228841-6a4e9b00-994d-11eb-901a-5ff385ed8188.png)

>Finally, an invalid format is now being inserted, which will trigger a message informing that the CNPJ is invalid:

>![image](https://user-images.githubusercontent.com/38429356/114229120-caddd800-994d-11eb-8cec-977e6d348332.png)

# Exercise 2 - Validate CNPJ digits
This exercise is similar to the first, one, but it will also check if the digits of the CNPJ are numeric:
>Here is a valid CNPJ:

>![image](https://user-images.githubusercontent.com/38429356/114230355-70457b80-994f-11eb-84b6-6a00e1b7df78.png)


>And here is an invalid CNPJ:

>![image](https://user-images.githubusercontent.com/38429356/114230309-63288c80-994f-11eb-8d8e-b58b81db7dc5.png)

# Exercise 5 - Simple Todo List
This exercise allows you to insert tasks in a to do list, and also makes it possible to see the list of tasks as well as remove them.
>At first, a menu will be shown prompting with the desired action:

>![image](https://user-images.githubusercontent.com/38429356/114230851-05e10b00-9950-11eb-9887-efd1b09da2ef.png)

>Here is an example of the insertion:

>![image](https://user-images.githubusercontent.com/38429356/114230989-3628a980-9950-11eb-8054-2950ea1fae96.png)

>In this picture, the task is being removed:

>![image](https://user-images.githubusercontent.com/38429356/114231244-8dc71500-9950-11eb-9ce1-f5591d55a157.png)

>Finally, here are all the tasks being listed, also showing that the task used in the previous examples was in fact, removed:

>![image](https://user-images.githubusercontent.com/38429356/114231371-bf3fe080-9950-11eb-9a2e-41f64218b44a.png)

>The tasks are being saved in a text file, so they will be saved even if the program is closed:

>![image](https://user-images.githubusercontent.com/38429356/114231646-134ac500-9951-11eb-96fc-b4ad67c66b85.png)

# Exercise 6 - Rest Client - World Clock
The sixth exercise will access the provided url to recover a json containing information regarding time and data, returning the current date/time hour in local and UTC timezones
>![image](https://user-images.githubusercontent.com/38429356/114232187-e1862e00-9951-11eb-9007-250e15e0f9e8.png)

# Exercise 7 - Rest Server - World Clock
The seventh exercise is similar to the previous one, but this time, it will return a json with the field "currentDateTime"
>![image](https://user-images.githubusercontent.com/38429356/114232419-3d50b700-9952-11eb-8ab1-f7a30b107c58.png)

# Exercise 8 - Entity Relationship Diagram - Simple Order Manager
This exercise shows the diagram for a database resposible for an Order Manager System.
<br/>It was modelled using the following principle:

>A client can have many orders, but each order belongs to a single client;

>Each order can have many items, but each item belongs to a specific order;

>Each item refers to a specific product, but each product can be included in many orders; 

![KaffaTest](https://user-images.githubusercontent.com/38429356/114286076-12d62b00-9a32-11eb-930d-9b9200178d93.png)


>In order to list all the orders with the number of items, the following query could be used:<br/>
```sql 
SELECT ORDR.OrderId, PRDT.ProductName, ORIT.OrderItemQuantity, ORIT.OrderItemTotalPrice
FROM Orders ORDR
INNER JOIN OrderItems ORIT ON ORDR.OrderId = ORIT.OrderID
INNER JOIN Products PRDT ON ORIT.ProductID = PRDT.ProductID;
```
>Additionally, if the total of items for each order is desired, the query below can be used:<br/>
```sql
SELECT ORIT.OrderID, COUNT(ORIT.OrderItemID) 
FROM Orders ORDR
INNER JOIN OrderItems ORIT ON ORDR.OrderId = ORIT.OrderID
INNER JOIN Products PRDT ON ORIT.ProductID = PRDT.ProductID
GROUP BY ORIT.OrderID;
```

# Exercise 9 - UX - Prototype
This exercise, although not needed, was done once it was possible to do so, and shows a screen for creating new projects regarding electric networks.<br/>
![image](https://user-images.githubusercontent.com/38429356/114234687-7a6a7880-9955-11eb-83df-16f3d8148f78.png)


# Company-Management-System
 A system that enables companies to define and monitor services. 
 
 ## Dont Forget:
 
 First of all you must create migrations.
 Position on BusinessApp.DataAccess
 <pre>
 $ dotnet ef migrations add NewInitialCreate --context BusinessAppContext --startup-project ../BusinessApp.WebUI
 $ dotnet ef database update --context BusinessAppContext --startup-project ../BusinessApp.WebUI
 </pre>
 Position on BusinessApp.WebUI
 <pre>
 $ dotnet ef migrations add NewIdentityUser --context ApplicationContext --startup-project ../BusinessApp.WebUI
 $ dotnet ef database update --context ApplicationContext --startup-project ../BusinessApp.WebUI
 </pre>
 
## What this system does:

### As Admin:
You can login ass admin. <br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/1.gif)<br>

You can creeate company. <br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/2.gif)<br>

Every admin must be have a company.<br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/3.gif)<br>

You can confirm users sign up applications.<br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/12.gif)<br>


You can define a service to the company.<br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/9.gif)<br>

You can create a department. <br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/4.gif)<br>

You can add employees to the company.<br>
You can create user role.<br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/5.gif)<br>
You can define employees to departments.<br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/14.gif)<br>
You can define Service to the Departments.<br>
You can create a service.<br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/8.gif)<br>
<hr>
You can define services to companies.<br>
You can create user (user, employee, admin). <br>

![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/6.gif)<br>

<hr>
You can answer requests.<br>
You can assign requests to employees.<br>
You can assign assigned requests to employees or departments.<br>
You can list program logs.<br>

![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/10.gif)<br>

<hr>

### As an Employee:
You can assign requests to employees in your department.<br>
You can assign requests to other departments.<br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/18.gif)<br>

![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/19.gif)<br>
<hr>

You can change the services of the requests.<br>
You can answer requests.<br>

### As a user:
You can login or gin up as user.<br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/11.gif)<br>
<hr>

You must confirm your account.<br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/13.gif)<br>
<hr>

You can create a request.<br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/15.gif)<br>
<hr>

You can view your requests. <br>
![alt text](https://github.com/Olymposrec/Company-Management-System/blob/main/gifs/16.gif)<br>
<hr>


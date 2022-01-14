# Descprition of the Task: create a web application to manage projects and tasks.
Current repository contains the realization of the "Task" using two ways: Web Api and MVC.

# Subrepositories

### - cv_project_1
This directory contains all the source code that completes the Task using Web Api. 

This solutions meets all requirements asked to complete the task including Swagger, Validations, Functionality. However, it does not have any design, but it can process all types of quries: add/edit/view/delete projects and tasks. The purpose of this solutions is to show the ablity to complete specifications, not to make an userfriendly program.

### - cv_project_2
This directory contains all the source code that completes the Task using Model View Controller. 

This solutions has only one failed requirement - it does not support Swagger api. The reason for this is that, MVC type has it's own routing schema is not matched with Swagger routing style. However, it has the designed pages with forms and buttons, which is more like a real application. It also has required validations for wrong inputs, and it support all the functionality to add/edit/view/delete projects and tasks. I keep this repository because swagger is mainly helpful for developers, and I believe this project is more user oriented.

# How to run application

### *Requirements:
Before building the application, make sure that the dotnet command is available in you machine. For this, .NET SDK 6.0 must be installed on the machine. To install go to [install net core 6 sdk](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

### Clone this repository
```bash
$ git clone https://github.com/aibarito/net_cv_project.git [destinationPath]
$ cd [destinationPath]
```
### Choose one of cv_project_1 (webapi) or cv_project_2 (mvc)
```bash
$ cd cv_project_{1 or 2 based on choice}
```
### Build
```bash
$ dotnet build
$ dotnet run
```
It will run the client locally and in your browser, go to this link -> http://localhost:7270/swagger (for cv_project_1) or http://localhost:5246 (for cv_project_2)
\
(If the links doesn't work, then check the message shown in the terminal, it must say: "Now listening on: {address}", and follow the {address})
# Troubleshooting

### Important notes:
1) The server runs on the Azure Portal remotely, but the client site is hosted locally.



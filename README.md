# Pierre's Sweet and Savory Treats

#### Epicodus C# Advanced Database Practice 1.15.2021

#### by _**Kevin Kirkley**_

## Description
Pierre is back again, this time wanting a MVC application that features Authentication. This program allows users to list out the delicious baked treats that the bakery has in stock. It also allows users to generate Flavor profiles which then can be applied to the treats in order to classify them. Using Identity, the creation, editing and deletion of both the Treat class objects as well as the Flavor class objects require Authorization provided through account creation and login. Users can create an account, log in to that account and log out of the account. 

## User Stories

* There should be a many-to-many relationship between Treats and Flavors. A treat can have many flavors (such as sweet, savory, spicy, or creamy) and a flavor can have many treats. For instance, the "sweet" flavor could include chocolate croissants, cheesecake, and so on.
* A user should be able to navigate to a splash page that lists all treats and flavors. Users should be able to click on an individual treat or flavor to see all the treats/flavors that belong to it.

## Setup/Installation Requirements

### Software Requirements
1. Internet Browser
2. A code editor such as VSCode in order to view or edit codebase. 
3. netcore2.2
4. MySQL
5. MySQLWorkbench.

### Open by downloading:
1. Download the [repository](https://github.com/kevinkirkl3y/PierresAuth.Solution.git) onto your computer by clicking the 'clone or download button'.
2. Open within your text editor and navigate to the `PierresAuth.Solution/PierresAuth` folder and run `dotnet restore` in your console.

### Open with Bash/GitBash:
1. Clone this repository onto your computer: 
```
git clone https://github.com/kevinkirkl3y/PierresAuth.Solution.git
```
2. Navigate into the `PierresAuth.Solution` directory and open in VSCode or preferred text editor using `code .` in your terminal.
3. Open within your text editor and navigate to the `PierresAuth.Solution/PierresAuth` folder and run `dotnet restore` in your console.

### AppSettings
* This project requires an AppSettings file. Create your `appsettings.json` file in the main PierresAuth file following the format below. Use your unique password that you created duing MySQLWorkbench installation:

```  
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=<firstName_lastName_PierresAuth>;uid=root;pwd=<YourPassword>;"
  }
} 
```
* Update the Server, Port and User Id as needed.
### Setup of MySQL Database 

* Navigate to `PierresAuth.Solution/PierresAuth` and type `dotnet ef migrations add <MigrationName>` into the terminal. 
* Then, type `dotnet ef database update` into the terminal to create your database tables.


## Known Bugs
* No known bugs at this time. 1.15.2021


## Support and contact detail

_Contact Kevin Kirkley at [kevinmkirkley@gmail.com](mailto:kevinmkirkley@gmail.com) with and questions, concerns or additions._


## Technologies Used 

* _C#_
* _MVC_
* _VSCode_
* _netcore2.2_
* _MySQL_
* _MySQLWorkbench_
* _Entity_
* _Identity_


### License

Copyright (c) 2020 **_Kevin Kirkley_**
This software is licensed under the MIT license.

Copyright 2020 Kevin Kirkley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
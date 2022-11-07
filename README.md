# Project name
>Vidly - Video Rental Store Application

## Table of Contents
* [General information](#general-information)
* [Technologies used](#technologies-used)
* [Setup](#setup)
* [Author](#author)

## General information
This project has been created following online course The Complete ASP.NET MVC Course by Mosh Hamedani on Udemy in order to get a first grip on that technology.
It provides basic functionality for a rental store staff, including regular staff members and managers. Basic third-party sign-on is available. 
It still misses few features and unit tests, but is kept deployment-ready.

## Technologies used
Technologies, frameworks, NuGet third parties' libraries/plugins etc.

### Back-end
- ASP.NET MVC 5
- DB: local SQL Server
- ORM: Entity Framework 6
- REST API
- AutoMapper: a simple little library built to solve a deceptively complex problem - getting rid of code that mapped one object to another
- Validation: on the client side
- Anti-forgery Tokens
- Authentication: via attributes

### Front-end
- Razor pages
- Boostrap (CSS)
- Bootbox.js: a small JavaScript library which allows you to create programmatic dialog boxes using Bootstrap modals, without having to worry about creating, managing, or removing any of the required DOM elements or JavaScript event handlers
- AJAX (Asynchronous JavaScript And XML): allows web pages to be updated asynchronously by exchanging data with a web server behind the scenes. This means that it is possible to update parts of a web page, without reloading the whole page.
- jQuery: a fast, small, and feature-rich JavaScript library. It makes things like HTML document traversal and manipulation, event handling, animation, and Ajax much simpler with an easy-to-use API that works across a multitude of browsers. With a combination of versatility and extensibility, jQuery has changed the way that millions of people write JavaScript
- Bootswatch: free themes for Bootstrap (Lumen)
- DataTables: a plug-in for the jQuery Javascript library. It is a highly flexible tool, built upon the foundations of progressive enhancement, that adds all of these advanced features to any HTML table
- Typeahead.js: flexible JavaScript library that provides a strong foundation for building robust typeaheads
- Bootbox.js: a small JavaScript library which allows you to create programmatic dialog boxes using Bootstrap modals, without having to worry about creating, managing, or removing any of the required DOM elements or JavaScript event handlers
- toastr: a Javascript library for non-blocking notifications.

### Unit tests
- NUnit Framework v3.13.3.0
- NUnit3 TestAdapter v4.3.0-alpha-net7.4
- Moq v4.17.0.0

### Diagnostics
- ELMAH (Error Logging Modules and Handlers): easy error logging and uptime monitoring service for .NET.
- Glimpse: Glimpse is a thriving and growing family of open source NuGet packages that provides detailed performance, debugging and diagnostic information for ASP.NET apps

## Setup
To run this project clone it locally and open with Visual Studio (preferably 2019 or newer).
Vidly should be set as the startup project to compile.
Required AppSettings.config file is stored on author's GitHub private Gist.
Reach out to the author to hand the over the file or re-create it with your own FacebookAppId and FacebookAppSecret.
Restore NuGet packages if needed.
Re-create the DB locally using EF command Update-Database. In case you get an error make sure empty App_Data folder exists in the project tree AND in the project directory. You may have to delete and re-create it.

You are good to go.

There are two publish profiles: GoDaddy and testing. More to be told soon.

## Author
Grzegorz Wengorz Inc.
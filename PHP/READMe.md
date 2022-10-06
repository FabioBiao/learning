
# commands
- install laravel globally
https://laravel.com/docs/9.x/installation#installation-via-composer

composer global require laravel/installer
- create new laravel app
laravel new first-app
-  run application
php artisan serve

# routing requests
inside routes folder, exists api and web routes.

The views are stored inside: 
- resources/views 

# controllers
- app/http/controllers
here we can add controllers
we can also create controllers via artisan
- php artisan make:controller HomeController
- php artisan make:controler -r (creates with a class)

# Views
- resources/views

## layouts 
- resources/views/layout.php

# main folder /public 
inside the /public is the index.php <- entry point of our application
example of view acessing our root files in our public  folder 
-  <link rel="stylesheet" href="{{ url('css/site.css') }}">

# resources controller (3.5)
- php artisan make:controller GuitarsController --resource

creates the controller, then we add a new route setting on resource

# databases 4.2    PHP uses eloquent
 
- php artisan make:migration --help
- php artisan make:model Guitar --migration
this creates a Guitar Model inside app/Models/ and migration inside the database/migrations

- php artisan migrate   - run the migration 

# create a request form
- php artisan make:request GuitarFormRequest
this creates a request form inside app/Requests/
there we can add validations and rules to add items to our guitar


- https://www.youtube.com/watch?v=AGE3wRKljkw
Intro 00:00
Set Up Your Environment 01:53
Routing Requests 07:31
Working With Query Data 14:38
Route URL Parameters 24:16
Routing to Controllers 31:40
Creating a View 40:02
Introducing Layouts 48:12
Working With Static Resources 56:28
Generating URLs for Routes 1:01:32
Organizing Views 1:04:59
Using Blade Directives 1:14:41
Showing and Linking Data 1:22:18
Setting Up the Database 1:29:49
Creating Migrations and Models 1:33:47
Saving Database Records 1:43:55
Validating User Input 1:52:53
Updating Data 2:00:31
Using Type Hints and Requests Classes 2:07:36
Using Mass Assignment 2:16:27
Conclusion 2:22:35
# RecipeShopper
Manage recipes, organize ingredients and generate shopping list! Awesome!

# Application Archtecture
The application is divided in two, front and back-end. The front end was designed in modern Angular, with Bootstrap for styling.
The back-end is a .Net Core DDD application that exposes CRUD methods for maintaining ingredients, recipes and shoplists.

## Front-end
The front end app can be run using the command 'ng serve' and will be provided as localhost port 4200. There are three functionalities to enable users to create/edit/delete ingredients, create recipes, and generate shopping lists with existing recipes.
It is divided in three Angular Modules, and all development used Angular CLI for objects generation.
The forms were created using two available approaches: classic and reactive. 

## Back-end

Back end application can be run by using the command 'dotnet run MBC.RecipeShopper.Web.Api.sln --project Api/MBC.RecipeShopper.Api.csproj'. It is going to be serve at port 5000 and 5001 for https. It also has Swagger API documentation that is accessible by its root (https://localhost:5001 is redirected to index.html).
There are many projects that composes the back end. Mainly there are three tiers: Web API, service and repository. And the project has two modules, Shared and Dbo (which refers to Dbo database schema).
Data navigates through the application tiers encapsulated in commands, respecting the CQRS design pattern, and is paired with database using EntityInfo abstractions.
Database connection is handled by Entity Framework and was designed using Code-First approach.

# Database
In order to create the database is necessary to use the scripts 'RecipeShopperScripts.sql' and 'RecipeShopper.Insert.sql'. The fist is for database objects creation and second for sample data insertion. There are few tables and the structure is basicly Ingredient - Recipe - Shoplist. The ingredients table is referenced by Recipe and Shoplists in N-N relationships, from which derives the RecipeIngredient and ShoplistIngredient tables.

Created by Marcos Braga Choma.

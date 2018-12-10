create database RecipeShopper
go
use RecipeShopper
go
if object_id('ShoplistIngredient', 'u') is not null
    drop table ShoplistIngredient
go
if object_id('RecipeIngredient', 'u') is not null
    drop table RecipeIngredient
go
if object_id('Shoplist', 'u') is not null
    drop table Shoplist
go
if object_id('Recipe', 'u') is not null
    drop table Recipe
go
if object_id('Ingredient', 'u') is not null
    drop table Ingredient
go
if object_id('AmountType', 'u') is not null
    drop table AmountType
go

create table Ingredient (
	id int identity(1,1) primary key,
	description varchar(100)
)
create table AmountType (
	id int identity(1,1) primary key,
	description varchar(100)
)
create table Shoplist (
	id int identity(1,1) primary key,
	creationDate datetime not null
)

create table ShoplistIngredient (
	id int identity(1,1) primary key,
	shoplistId int foreign key references Shoplist(id),
	ingredientId int foreign key references Ingredient(id),
	amountTypeId int foreign key references AmountType(id),
	amount decimal
)

create table Recipe (
	id int identity(1,1) primary key,
	name varchar(100),
    steps varchar(MAX)
)

create table RecipeIngredient (
	id int identity(1,1) primary key,
	recipeId int foreign key references Recipe(id),
	ingredientId int foreign key references Ingredient(id),
	amountTypeId int foreign key references AmountType(id),
	amount decimal
)
go
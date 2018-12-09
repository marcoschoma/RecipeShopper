if object_id('Shoplist', 'u') is not null
    drop table Shoplist
go
create table Shoplist (
	id int identity(1,1) primary key,
	creationDate datetime not null
)
go

if object_id('ShoplistIngredient', 'u') is not null
    drop table ShoplistIngredient
go
create table ShoplistIngredient (
	id int identity(1,1) primary key,
	shoplistId int foreign key FK_ShoplistIngredient_Shoplist references Shoplist(id),
	ingredientId int foreign key FK_ShoplistIngredient_Ingredient references Ingredient(id),
	amountTypeId int foreign key FK_ShoplistIngredient_AmountType references AmountType(id),
	amount decimal
)

if object_id('Ingredient', 'u') is not null
    drop table Ingredient
go
create table Ingredient (
	id int identity(1,1) primary key,
	description varchar(100)
)

if object_id('AmountType', 'u') is not null
    drop table AmountType
go
create table AmountType (
	id int identity(1,1) primary key,
	description varchar(100)
)

if object_id('Recipe', 'u') is not null
    drop table Recipe
go
create table Recipe (
	id int identity(1,1) primary key,
	name varchar(100),
    steps varchar(MAX)
)

if object_id('RecipeIngredient', 'u') is not null
    drop table RecipeIngredient
go
create table RecipeIngredient (
	id int identity(1,1) primary key,
	ingredientId int foreign key FK_RecipeIngredient_Ingredient references Ingredient(id),
	amountTypeId int foreign key FK_RecipeIngredient_AmountType references AmountType(id),
	amount decimal
)
go
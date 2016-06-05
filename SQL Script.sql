use CRM;
IF OBJECT_ID('dbo.users', 'U') IS NOT NULL 
  DROP TABLE dbo.users; 
create table users
(
	id int identity(1,1) not null primary key,
	name varchar(50) not null,
	login varchar(100) not null,
	password varbinary(34) not null
);

insert into users(name, login,password ) 
values ('Testowy','adrian.kasia.pk2106@gmail.com',(select HASHBYTES('MD5','Politechnika*2016')));

IF OBJECT_ID('dbo.mailBox', 'U') IS NOT NULL 
  DROP TABLE dbo.mailBox; 
create table mailBox
(
	id int identity(1,1) primary key,
	type bit, --0 odebrany, 1 wyslany
	name varchar(50) not null, 
	mail varchar(50) not null, 
	tittle varchar(255) not null,
	messageText varchar(max) not null,
	messageDate date not null,
	userId int foreign key REFERENCES users(id)
);

IF OBJECT_ID('dbo.attachment', 'U') IS NOT NULL 
  DROP TABLE dbo.attachment; 
CREATE TABLE attachment
(
	id int IDENTITY(1,1) NOT NULL primary key,
	messageId int NOT NULL,
	data image NOT NULL,
	name varchar(255) NOT NULL
);
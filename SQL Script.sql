use CRM;
IF OBJECT_ID('dbo.city', 'U') IS NOT NULL 
  DROP TABLE dbo.city; 
create table city
(
	id int IDENTITY(1,1) NOT NULL primary key,
	name varchar(255),
	postCode varchar(6)
)
IF OBJECT_ID('dbo.prefix', 'U') IS NOT NULL 
  DROP TABLE dbo.prefix; 
create table prefix
(
	id int IDENTITY(1,1) NOT NULL primary key,
	prefix varchar(20)
)
IF OBJECT_ID('dbo.street', 'U') IS NOT NULL 
  DROP TABLE dbo.street; 
create table street
(
	id int IDENTITY(1,1) NOT NULL primary key,
	id_city int foreign key REFERENCES city(id),
	id_prefix int foreign key REFERENCES prefix(id),
	name varchar(255)
)

IF OBJECT_ID('dbo.company', 'U') IS NOT NULL 
  DROP TABLE dbo.company; 
create table company
(
	id int IDENTITY(1,1) NOT NULL primary key,
	companyName varchar(255) not null,
	id_street int foreign key REFERENCES street(id) not null,
	houseNo varchar(20) not null, 
	nip varchar (15),
	tel varchar (15),
	mail varchar (100)
)

IF OBJECT_ID('dbo.client', 'U') IS NOT NULL 
  DROP TABLE dbo.client; 
create table client
(
	id int IDENTITY(1,1) NOT NULL primary key,
	id_company int foreign key REFERENCES company(id) not null,
	mail varchar (100) not null,
	tel varchar (15),
	name varchar (50),
	secondName varchar (50)
)

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
	type int, --0 odebrany, 1 wyslany
	name varchar(50) not null, 
	mail varchar(50) not null, 
	tittle varchar(255) not null,
	messageText varchar(max) not null,
	messageDate datetime not null default GETDATE(),
	userId int foreign key REFERENCES users(id),
	clientId int foreign key REFERENCES client(id),
	readMail bit 
);

IF OBJECT_ID('dbo.attachment', 'U') IS NOT NULL 
  DROP TABLE dbo.attachment; 
CREATE TABLE attachment
(
	id int IDENTITY(1,1) NOT NULL primary key,
	messageId int NOT NULL foreign key REFERENCES mailBox(id),
	data image NOT NULL ,
	name varchar(255) NOT NULL
);


----przykladowe dane

insert into city(name, postcode) values ('rudawa', '32-064');
insert into prefix(prefix) values ('');
insert into street(id_city, id_prefix, name) values (1,1,'Nielepice ul. Sosnowa');
insert into company(companyName, id_street, houseno, nip, tel, mail) values
('Adrian', 1, '11', '11111111', '728578890', 'adrian.grzegorek@gmail.com')
insert into client(id_company, mail, tel, name, secondname) values (1, 'siersciuch1991@gmail.com', '728578890', 
'Adrian', 'Grzegorek');
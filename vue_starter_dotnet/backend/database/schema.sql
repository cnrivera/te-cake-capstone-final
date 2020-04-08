﻿
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the DemoDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='DemoDB')
DROP DATABASE DemoDB;
GO

-- Create a new DemoDB Database
CREATE DATABASE DemoDB;
GO

-- Switch to the DemoDB Database
USE DemoDB
GO

BEGIN TRANSACTION;

CREATE TABLE users
(
	id			int			identity(1,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

	constraint pk_users primary key (id)
);
CREATE TABLE cakeinfo
(
	id			int			identity(1,1),
	name		varchar(50)	not null,
	price		float		not null,
	style		varchar(50)	not null,
	size		varchar(50) not null,
	flavor		varchar(50) not null,
	icing		varchar(50) not null,
	filling		varchar(50),
	description varchar(500) not null,
	image_path	varchar(50) default('placeholder-image'),
	available	bit			default(1)
	

	constraint pk_cakes primary key(id)
);


COMMIT TRANSACTION;
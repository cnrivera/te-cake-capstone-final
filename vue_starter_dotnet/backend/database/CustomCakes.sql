
-- Switch to the CakesDB Database
USE CakesDB
GO

BEGIN TRANSACTION;

CREATE TABLE styles
(
	id			int			identity(1,1),
	available bit not null,
	style varchar (50) not null,
	price_multiplier float not null,
	
	constraint pk_styles primary key (id)
);
CREATE TABLE sizes
(
	id			int			identity(1,1),
	available bit not null,
	size varchar (50) not null,
	price_multiplier float not null,

	constraint pk_sizes primary key(id)
);

CREATE TABLE flavors
(
	id			int			identity(1,1),
	available bit not null,
	flavor varchar (50) not null,
	price_multiplier float not null,

	constraint pk_flavors primary key(id)
);

CREATE TABLE frostings
(
	id			int			identity(1,1),
	available bit not null,
	frosting varchar (50) not null,
	price_multiplier float not null,

	constraint pk_frostings primary key(id)
);

CREATE TABLE fillings
(
	id			int			identity(1,1),
	available bit not null,
	filling varchar (50) not null,
	price_multiplier float not null,

	constraint pk_fillings primary key(id)
);

CREATE TABLE style_size
(
	style_id int not null,
	size_id int NOT NULL,

	constraint fk_style_size_style_id foreign key (style_id) references styles (id),
	constraint fk_style_size_size_id foreign key (size_id) references sizes (id)
);

CREATE TABLE cakes
(
	id			int			identity(1,1),
	name			varchar(50)	not null,
	price			float		not null,
	style_id		int	not null,
	size_id 		int not null,
	flavor_id		int not null,
	frosting_id		int not null,
	filling_id		int not null,
	description varchar(500) not null,
	image_path	varchar(50) default('placeholder-image'),
	available	bit			default(1)
	

	constraint pk_cakes primary key(id)
	constraint fk_cakes_style_id foreign key (style_id) references styles (id),
	constraint fk_cakes_size_id foreign key (size_id) references sizes (id),
	constraint fk_cakes_flavor_id foreign key (flavor_id) references flavors (id),
	constraint fk_cakes_frosting_id foreign key (frosting_id) references frostings (id),
	constraint fk_cakes_filling_id foreign key (filling_id) references fillings (id),
);



COMMIT TRANSACTION;
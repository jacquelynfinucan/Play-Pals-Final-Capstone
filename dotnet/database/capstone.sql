USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO

CREATE TABLE user_profile (
	user_id int NOT NULL,
	first_name varchar(50) NOT NULL, 
	last_name varchar(50) NOT NULL, 
	zip_code varchar(15) NOT NULL

	CONSTRAINT [PK_user_profile] PRIMARY KEY (user_id, last_name),
    CONSTRAINT [FK_user_profile_users] FOREIGN KEY (user_id) REFERENCES [users] (user_id)
)

CREATE TABLE pet_profile (
	pet_id int IDENTITY(1,1) NOT NULL,
	pet_name varchar(50) NOT NULL, 
	animal_type varchar(50) NOT NULL, --default to dog?
	breed varchar(50) NOT NULL, 
	age int NULL, --option to leave empty
	size int NOT NULL, --small=1, medium=2, large=3 (extra large & extra small or good enough?)
	is_male bit NOT NULL, 
	is_spayed_neutered bit NOT NULL, 
	descrption varchar(200) NULL --option to leave empty

	CONSTRAINT [PK_pet_profile] PRIMARY KEY (pet_id)
)

CREATE TABLE users_pets (
	user_id int NOT NULL, 
	pet_id int NOT NULL

	CONSTRAINT [PK_users_pets] PRIMARY KEY (user_id, pet_id),
    CONSTRAINT [FK_users_pets_users] FOREIGN KEY (user_id) REFERENCES [users] (user_id),
	CONSTRAINT [FK_users_pets_pet_profile] FOREIGN KEY (pet_id) REFERENCES [pet_profile] (pet_id)
)

CREATE TABLE personality_traits (
	personality_id int NOT NULL,
	personality_name varchar(75) NOT NULL

	CONSTRAINT [PK_personality_traits] PRIMARY KEY (personality_id)
)

INSERT INTO personality_traits (personality_id, personality_name) VALUES (1, 'Energetic');
INSERT INTO personality_traits (personality_id, personality_name) VALUES (2, 'Calm');
INSERT INTO personality_traits (personality_id, personality_name) VALUES (3, 'Shy');
INSERT INTO personality_traits (personality_id, personality_name) VALUES (4, 'Anxious');
INSERT INTO personality_traits (personality_id, personality_name) VALUES (5, 'Aggressive');
INSERT INTO personality_traits (personality_id, personality_name) VALUES (6, 'Not good with kids');
INSERT INTO personality_traits (personality_id, personality_name) VALUES (7, 'Not good with animals other than dogs');
INSERT INTO personality_traits (personality_id, personality_name) VALUES (8, 'House Trained');
INSERT INTO personality_traits (personality_id, personality_name) VALUES (9, 'Command Trained');

CREATE TABLE pets_personality_traits (
	pet_id int NOT NULL, 
	personality_id int NOT NULL

CONSTRAINT [PK_pets_personality_traits] PRIMARY KEY (pet_id, personality_id),
CONSTRAINT [FK_pets_personality_traits_pet_profile] FOREIGN KEY (pet_id) REFERENCES [pet_profile] (pet_id),
CONSTRAINT [FK_pets_personality_traits_personality_traits] FOREIGN KEY (personality_id) REFERENCES [personality_traits] (personality_id),
)

CREATE TABLE play_dates (
	play_date_id int IDENTITY(1,1) NOT NULL,
	host_user_id int NOT NULL, 
	host_pet_id int NOT NULL, 
	guest_pet_id int NOT NULL, 
	date_time datetime NOT NULL

	CONSTRAINT [PK_play_dates] PRIMARY KEY (play_date_id), 
	CONSTRAINT [FK_play_dates_users] FOREIGN KEY (host_user_id) REFERENCES [users] (user_id), 
	CONSTRAINT [FK_play_dates_pet_host] FOREIGN KEY (host_pet_id) REFERENCES [pet_profile] (pet_id),
	CONSTRAINT [FK_play_dates_pet_guest] FOREIGN KEY (guest_pet_id) REFERENCES [pet_profile] (pet_id)
)
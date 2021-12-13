USE final_capstone
GO

--populate test users with a default password of "password"
INSERT INTO users (username, password_hash, salt, user_role) 
VALUES ('User','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user'),	--user_id = 1
	('Admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin'),	--user_id = 2
	('Mark','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user'),		--user_id = 3
	('Zach','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user'),		--user_id = 4
	('Ryan','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user'),		--user_id = 5
	('Jacque','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user'),		--user_id = 6
	('Kiran','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user'),		--user_id = 7
	('David','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');		--user_id = 8

--populate test profiles for the above users
INSERT INTO user_profile (user_id, first_name, last_name, email, zip_code) 
VALUES (1, 'userFirst', 'userLast', 'user@gmail.com', 41000),
	(2, 'adminFirst', 'adminLast', 'admin@gmail.com', 41000),
	(3, 'Mark', 'Spieth', 'mark@gmail.com', 41000),
	(4, 'Zach', 'Laird', 'zach@gmail.com', 41000),
	(5, 'Ryan', 'Garro', 'ryan@gmail.com', 41000),
	(6, 'Jacquelyn', 'Finucan', 'jacquelyn@gmail.com', 41000),
	(7, 'Kiran', 'Meyers', 'kirian@gmail.com', 41000),
	(8, 'David', 'Ferreira', 'david@gmail.com', 41000);

--populate test pets for the above users
INSERT INTO pet_profile (pet_name, animal_type, breed, age, size, is_male, is_spayed_neutered, description)
VALUES ('Bolt', 'Dog', 'Bulldog', 5, 3, 1, 1, 'Good boy!'),				--pet_id = 1
	('Hunter', 'Dog', 'Poodle', 2, 2, 0, 0, 'Very energetic'),			--pet_id = 2
	('Alpha', 'Dog', 'Beagle', 4, 1, 1, 1, 'Sleepy'),					--pet_id = 3
	('Rain', 'Dog', 'Golden Retriever', 6, 3, 0, 0, 'Very shy'),		--pet_id = 4
	('Ritz', 'Dog', 'German Shepherd', 1, 1, 1, 1, 'Bites!'),			--pet_id = 5
	('Cinder', 'Dog', 'Beagle', 4, 3, 0, 0, 'Playful'),					--pet_id = 6
	('Bixby', 'Dog', 'Poodle', 3, 2, 1, 1, 'Loud barker'),				--pet_id = 7
	('Arrow', 'Dog', 'Bulldog', 5, 2, 0, 0, 'Loves to play fetch');		--pet_id = 8

--assign person
INSERT INTO pets_personality_traits (pet_id, personality_id)
VALUES (1, 1), (1, 4), (1, 8), 
	(2, 2), (2, 8), 
	(3, 4), (3, 5), (3, 6), (3, 8), (3, 9)

--assign the test pets to users
INSERT INTO users_pets (user_id, pet_id)
VALUES (1,1),
	(2,2),
	(3,3),
	(4,4),
	(5,5),
	(6,6),
	(7,7),
	(8,8);

--populate test play dates
INSERT INTO play_dates (title, host_user_id, host_pet_id, guest_pet_id, date_time)
VALUES ('City Park Play Date', 1, 1, 2, GETDATE()),									--play_date_id = 1
	('At Home Play Date', 2, 2, 5, GETDATE()),										--play_date_id = 2
	('Jogging and Dogs', 3, 3, 2, GETDATE()),										--play_date_id = 3
	('Meet and Greet', 4, 4, 1, GETDATE()),											--play_date_id = 4
	('Dog Yoga', 5, 5, 7, GETDATE()),												--play_date_id = 5
	('Cinder Birthday Get Together', 6, 6, 4, GETDATE()),							--play_date_id = 6
	('New Puppies', 7, 7, 6, GETDATE()),											--play_date_id = 7
	('Lake Visit', 8, 8, 3, GETDATE()),												--play_date_id = 8
	('No Message Test', 1, 1, 3, GETDATE());										--play_date_id = 9

--populate test messages
INSERT INTO play_date_messages (play_date_id, from_user_id, from_pet_id, post_date, message_text)
VALUES (1, 1, 1, DATEADD(hour, -2, GETDATE()), 'This is a message from User!'),
	(1, 2, 2, DATEADD(hour, -1, GETDATE()), 'Thanks for the play date!'),
	(2, 2, 2, DATEADD(hour, -2, GETDATE()), 'This is a message from Admin!'),
	(2, 5, 5, DATEADD(hour, -1, GETDATE()), 'Thanks for the play date!'),
	(3, 3, 3, DATEADD(hour, -2, GETDATE()), 'This is a message from Mark!'),
	(3, 2, 2, DATEADD(hour, -1, GETDATE()), 'Thanks for the play date!'),
	(4, 4, 4, DATEADD(hour, -2, GETDATE()), 'This is a message from Zach!'),
	(4, 1, 1, DATEADD(hour, -1, GETDATE()), 'Thanks for the play date!'),
	(5, 5, 5, DATEADD(hour, -2, GETDATE()), 'This is a message from Ryan!'),
	(5, 7, 7, DATEADD(hour, -1, GETDATE()), 'Thanks for the play date!'),
	(6, 6, 6, DATEADD(hour, -2, GETDATE()), 'This is a message from Jacque!'),
	(6, 4, 4, DATEADD(hour, -1, GETDATE()), 'Thanks for the play date!'),
	(7, 7, 7, DATEADD(hour, -2, GETDATE()), 'This is a message from Kiran!'),
	(7, 6, 6, DATEADD(hour, -1, GETDATE()), 'Thanks for the play date!'),
	(8, 8, 8, DATEADD(hour, -2, GETDATE()), 'This is a message from David!'),
	(8, 3, 3, DATEADD(hour, -1, GETDATE()), 'Thanks for the play date!');
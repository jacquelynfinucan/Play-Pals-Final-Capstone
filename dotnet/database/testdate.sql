USE final_capstone
GO

--populate test users with a default password of "password"
INSERT INTO users (username, password_hash, salt, user_role) 
VALUES ('Alex','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user'),	--user_id = 1 user
	('Chelsea','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin'),	--user_id = 2 admin
	('Mark','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user'),		--user_id = 3
	('Zach','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user'),		--user_id = 4
	('Ryan','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user'),		--user_id = 5
	('Jacquelyn','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user'),	--user_id = 6
	('Kiran','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user'),		--user_id = 7
	('David','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');		--user_id = 8

--populate test profiles for the above users
INSERT INTO user_profile (user_id, first_name, last_name, email, zip_code) 
VALUES (1, 'Alex', 'Moon', 'alex@gmail.com', 42114), --user
	(2, 'Chelsea', 'Cooper', 'chelsea@gmail.com', 41105), --admin
	(3, 'Mark', 'Spieth', 'mark@gmail.com', 41000),
	(4, 'Zach', 'Laird', 'zach@gmail.com', 44110),
	(5, 'Ryan', 'Garro', 'ryan@gmail.com', 41000),
	(6, 'Jacquelyn', 'Finucan', 'jacquelyn@gmail.com', 44111),
	(7, 'Abigail', 'Ward', 'abby@gmail.com', 44107),
	(8, 'David', 'Ferreira', 'david@gmail.com', 41123);

--populate test pets for the above users
INSERT INTO pet_profile (pet_name, animal_type, breed, age, size, is_male, is_spayed_neutered, description)
VALUES ('Bolt', 'Dog', 'Bulldog', 5, 1, 1, 1, 'Good boy!'),				--pet_id = 1
	('Toddy', 'Dog', 'Rottweiler chow chow mix', 3, 3, 1, 1, 'Very energetic, loves fetch'), --pet_id = 2
	('Flopsy', 'Dog', 'Beagle', 10, 1, 1, 1, 'Well behaved and gentle'),			--pet_id = 3
	('Raindance', 'Dog', 'Golden Retriever', 6, 3, 0, 0, 'Very shy and quiet'),		--pet_id = 4
	('Jerry', 'Dog', 'German Shepherd', 1, 3, 1, 1, 'Loves belly rubs!'),			--pet_id = 5
	('Cinderella', 'Dog', 'Beagle', 4, 1, 0, 0, 'Rambunctious pupper that loves bacon'),--pet_id = 6
	('Sir Bixby', 'Dog', 'Shih Tzu', 3, 2, 1, 1, ''),						--pet_id = 7
	('Vida', 'Dog', 'Bulldog', 5, 2, 0, 0, 'Loud barker, loves to chase squirrels'), --pet_id = 8
	('Mrs. Squishy', 'Dog', 'Pomeranian', 13, 1, 0, 1, 'Fluffy and dignified, loves dressing up'), --pet_id = 9
	('Gumby', 'Dog', 'Pug', 8, 2, 1, 0, 'Puggalicious!'),			--pet_id = 10
	('Blue', 'Dog', 'Husky', 2, 3, 1, 1, 'Typical husky-good digger and loves to run'), --pet_id = 11
	('Gracie', 'Dog', 'Mixed', 3, 1, 0, 1, '');				--pet_id = 12

--assign personality traits
INSERT INTO pets_personality_traits (pet_id, personality_id)
VALUES (1, 1), (1, 4), (1, 8), 
	(2, 1), (2, 6), (2, 8), 
	(3, 4), (3, 5), (3, 6), (3, 8), (3, 9),
	(4, 2), (4, 6), (4, 4),
	(5, 1), (5, 9), (5, 8),
	(6, 6), (6, 7), (6, 1),
	(7, 7),
	(8, 4), (8, 5), (8, 8),
	(9, 2), (9,8), (2,9),
	(10, 1), (10, 4), (10, 7), (10, 9),
	(11,1), (11,5), (11,8), (11,9),
	(12,2), (12,4), (12,8), (12,9)

--assign the test pets to users
INSERT INTO users_pets (user_id, pet_id)
VALUES (1,1),
	(2,2), (2,9),
	(3,3),
	(4,4),
	(5,8),
	(6,6), (6,11),
	(7,7), (7,10),
	(8,5), (8,12);

--add two locations	
INSERT INTO location (location_id, location_name, latitude, longitude, formatted_address)
VALUES ('ChIJ6dnrD4_7MIgRyDZm8_T8P48', 'Wade Lagoon', 41.5060304, -81.6112139, '1919 E 107th St, Cleveland, OH 44106'),
('ChIJCRg1bEH8MIgR82sB2Njfn3M', 'Coventry PEACE Park', 41.5079923, -81.5784675, '2843 Washington Blvd, Cleveland Heights, OH 44118')

--populate test play dates
INSERT INTO play_dates (title, host_user_id, host_pet_id, guest_pet_id, date_time, address, status_id,location_id)
VALUES ('City Park Play Date', 1, 1, 6, GETDATE(),'1234 Main St Cleveland, OH 44111', 2,'ChIJ6dnrD4_7MIgRyDZm8_T8P48'),									--play_date_id = 1
	--('At Home Play Date', 2, 2, 5, GETDATE(),'567 Brick Blvd Lakewood, OH 44107', 2,'ChIJ6dnrD4_7MIgRyDZm8_T8P48'),										--play_date_id = 2
	('Jogging and Dogs', 2, 2, 6, GETDATE(),'1234 Main St Cleveland, OH 44111', 2,'ChIJ6dnrD4_7MIgRyDZm8_T8P48'),										--play_date_id = 3
	('Meet and Greet', 4, 4, 1, GETDATE(),'567 Brick Blvd Lakewood, OH 44107', 2,'ChIJ6dnrD4_7MIgRyDZm8_T8P48'),											--play_date_id = 4
	--('Dog Yoga', 5, 5, 7, GETDATE(),'89 Memory Lane Brooklyn, OH 44144', 2,'ChIJ6dnrD4_7MIgRyDZm8_T8P48'),												--play_date_id = 5
	('Cinder Birthday Get Together', 6, 6, 4, GETDATE(),'1234 Main St Cleveland, OH 44111', 2,'ChIJ6dnrD4_7MIgRyDZm8_T8P48'),							--play_date_id = 6
	('Weekly Exercise Regime', 7, 7, 6, GETDATE(),'89 Memory Lane Brooklyn, OH 44144', 2,'ChIJ6dnrD4_7MIgRyDZm8_T8P48'),											--play_date_id = 7
	--('Lake Visit', 8, 8, 3, GETDATE(),'567 Brick Blvd Lakewood, OH 44107', 2,'ChIJCRg1bEH8MIgR82sB2Njfn3M'),												--play_date_id = 8
	('Surprise Puppy Playdate!', 1, 1, 3, GETDATE(),'1234 Main St Cleveland, OH 44111', 1,'ChIJCRg1bEH8MIgR82sB2Njfn3M'),											--play_date_id = 9
	('Doggo playdate!', 7, 10, 12, GETDATE(),'89 Memory Lane Brooklyn, OH 44144', 1,'ChIJCRg1bEH8MIgR82sB2Njfn3M'),--Gumby(Kiran) requesting David(Gracie)
	--('Welcome to the Neighborhood', 2, 2, 1, GETDATE(),'1234 Main St Cleveland, OH 44111', 2,'ChIJCRg1bEH8MIgR82sB2Njfn3M'),
	--('New Puppies', 3, 3, 2, GETDATE(),'2468 Maple Tree Ave Shaker Heights, OH 44001', 3,'ChIJCRg1bEH8MIgR82sB2Njfn3M'),
	('Lets Play!', 3, 3, 6, GETDATE(),'9753 Doggie Drive Cleveland, OH 44111', 2,'ChIJCRg1bEH8MIgR82sB2Njfn3M');
	--('Playdate!', 2, 2, 5, GETDATE(),'9753 Doggie Drive Cleveland, OH 44111', 3,'ChIJCRg1bEH8MIgR82sB2Njfn3M'),
	--('New Dog Park Opening', 2, 1, 3, GETDATE(),'1357 Puppers Ave Rocky River, OH 44123', 1,'ChIJCRg1bEH8MIgR82sB2Njfn3M')

--populate test messages
INSERT INTO play_date_messages (play_date_id, from_user_id, from_pet_id, post_date, message_text)
VALUES (1, 1, 1, DATEADD(hour, -2, GETDATE()), 'So excited for the playdate! See you then!'),
	(1, 2, 2, DATEADD(hour, -1, GETDATE()), 'Thanks! Can''t wait!'),
	(2, 2, 2, DATEADD(hour, -2, GETDATE()), 'Thanks for accepting the playdate request!'),
	(2, 5, 5, DATEADD(hour, -1, GETDATE()), 'Such a good idea-can''t wait for our dogs to meet.'),
	(3, 3, 3, DATEADD(hour, -2, GETDATE()), 'Hooray another playdate on the books!'),
	(3, 2, 2, DATEADD(hour, -1, GETDATE()), 'Yay! Oh and remember to bring a water bottle this time.'),
	(4, 4, 4, DATEADD(hour, -2, GETDATE()), 'Can''t wait to meet you and Bolt.'),
	(4, 1, 1, DATEADD(hour, -1, GETDATE()), 'Same here for you and Raindance!'),
	(5, 5, 5, DATEADD(hour, -2, GETDATE()), 'Thanks for joining-let me know if you need to update the time.'),
	(5, 7, 7, DATEADD(hour, -1, GETDATE()), 'Great we''ll keep you posted.'),
	(5, 5, 5, DATEADD(hour, -1, GETDATE()), 'Oh and let''s keep an eye on the weather-won''t be much fun if it rains!'),
	(6, 6, 6, DATEADD(hour, -2, GETDATE()), 'Hope you accept the playdate request, would love to meet you!'),
	--(7, 7, 10, DATEADD(hour, -3, GETDATE()), 'Hi David. I can''t wait for Gumby to meet Gracie!'),
	--(7, 8, 12, DATEADD(hour, -2, GETDATE()), 'Yeah this is going to be fun!'),
	(7, 7, 10, DATEADD(hour, -1, GETDATE()), 'So I''m super excited for the playdate, but you should probably know that Gumby is actually a cat...hope that''s ok!');
	--(8, 8, 8, DATEADD(hour, -2, GETDATE()), 'This is a message from David!'),
	--(8, 3, 3, DATEADD(hour, -1, GETDATE()), 'Thanks for the play date!'),
	--(10, 3, 3, DATEADD(hour, -2, GETDATE()), 'Holiday Playdate for the puppers! I''m bringing wrapped treats for them to open.')
	--(15, 2, 2, DATEADD(hour, -1, GETDATE()), 'Let''s go check out the new dog park in River-hope you''re available!'),
	--(11, 3, 3, DATEADD(hour, -2, GETDATE()), 'Welcome Alex-hope your move in went well! Can''t wait to introduce you to Toddy!'),
	--(11, 1, 1, DATEADD(hour, -1, GETDATE()), 'Thanks! The neighborhood is so nice and welcoming-excited to get our dogs together.'),
	--(11, 3, 3, DATEADD(hour, -1, GETDATE()), 'Welcome Alex-hope your move in went well! Can''t wait to introduce you to Toddy!')
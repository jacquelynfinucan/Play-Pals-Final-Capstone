
USE final_capstone
GO

DELETE user_profile
INSERT INTO user_profile (user_id,first_name,last_name,email,zip_code)
VALUES (1,'test','testerson', 'test123@gmail.com', 41000),
(2,'admin','adminson','admin123@gmail.com', 41000)

DELETE pet_profile
INSERT INTO pet_profile (pet_name,animal_type,breed,age,size,is_male,is_spayed_neutered,description)
VALUES ('doggo1','dog','husky',5,3,1,1,'doggo description 1'),
('doggo2','dog','shiba inu',1,1,0,0,'doggo description 2'),
('doggo3','dog','shiba inu',2,2,1,1,'doggo description 3')

--SELECT * FROM pet_profile

INSERT INTO users_pets (user_id,pet_id)
VALUES (1,1),(2,2),(2,3)

--SELECT * FROM users_pets

INSERT INTO play_dates (host_user_id,host_pet_id,guest_pet_id,date_time)
VALUES (1,1,2,GETDATE()),
(2,2,1,GETDATE())

--SELECT * FROM play_dates
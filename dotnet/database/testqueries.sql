--SELECT * FROM play_dates
Select * from pet_profile

select * from pet_profile join users_pets on users_pets.pet_id = pet_profile.pet_id where user_id = 17

select *from pet_profilejoin pets_personality_traitson pet_profile.pet_id = pets_personality_traits.pet_idjoin personality_traitson pets_personality_traits.personality_id = personality_traits.personality_id

Select * from pets_personality_traits where pet_id = 1

select pet_profile.pet_id, pet_name, animal_type, breed, age, size, is_male, 
                                                    is_spayed_neutered, description, user_id, personality_id
                                                    from pet_profile JOIN users_pets on users_pets.pet_id = pet_profile.pet_id
                                                    JOIN pets_personality_traits on pet_profile.pet_id = pets_personality_traits.pet_id
                                                    where user_id = 2
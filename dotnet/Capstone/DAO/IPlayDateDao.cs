using Capstone.Models;
using System;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPlayDateDao
    {
        PlayDate GetAPlayDate(int playDateId);
        List<PlayDate> GetAllPlayDates();
        int AddAPlayDate(PlayDate newPlayDate);
        bool UpdateAPlayDate(PlayDate updatedPlayDate);
        bool DeleteAPlayDate(int playDateId);
        List<PlayDate> GetAllPlayDatesForHost(int hostUserId);
        List<PlayDate> GetAllPlayDatesForLocation(int locationId);

        List<FrontEndPlayDate> GetFrontEndPlayDatesForHost(int hostUserId);

        List<PlayDateThread> GetPlayDateThreadsForUser(int userID);

        PlayDateThread GetPlayDateThreadForPlayDateID(int playDateID);

        List<PlayDate> GetPlayDatesForUserByStatus(int userID, int statusID);
        //if we want to get play dates by id to include if they're a guest, we'd have to add guest_user_id to PlayDate model & database
    }
}

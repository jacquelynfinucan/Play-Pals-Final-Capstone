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
    }
}

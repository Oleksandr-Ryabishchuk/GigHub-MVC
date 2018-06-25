﻿using GigHub1.Core.Models;
using System.Collections.Generic;

namespace GigHub1.Core.Repositories
{
    public interface IAttendanceRepository
    {
        Attendance GetAttendance(int gigId, string userId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);

        void Add(Attendance attendance);
        void Remove(Attendance attendance);
    }
}
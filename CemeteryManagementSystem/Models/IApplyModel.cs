using System;

namespace CemeteryManagementSystem.Models
{
    public interface ApplyModel
    {
        DateTime birthDay { get; set; }
        DateTime deathDay { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string middleName { get; set; }
    }
}
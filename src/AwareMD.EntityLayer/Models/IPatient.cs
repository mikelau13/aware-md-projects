using System;

namespace AwareMD.EntityLayer.Models
{
    public interface IPatient
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        DateTime DateOfBirth { get; }        
    }
}

﻿using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities
{
    public class ChildSiblings:Entity
    {
        public string Id { get; set; }
        public string ChildId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EducationStatusId { get; set; }
        public string Job { get; set; }
        public Child Child { get; set; }
        public ChildSiblings()
        {

        }

        public ChildSiblings(string id, string childId, string firstName, string lastName, int age, string educationStatusId, string job):this()
        {
            Id = id;
            ChildId = childId;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            EducationStatusId = educationStatusId;
            Job = job;
        }
    }
}

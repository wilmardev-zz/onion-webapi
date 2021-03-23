using System;

namespace XpertGroup.Users.Domain.Entities
{
    public class User
    {
        public string UserName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedDays { get; set; }

    }
}

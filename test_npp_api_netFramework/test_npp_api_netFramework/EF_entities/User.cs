using System;
using System.Collections.Generic;

namespace test_sql.EF_entities
{
    public class User : BaseEntity
    {
       public string FirstName { get; set; }

       public string LastName { get; set; }

       public string MiddleName { get; set; }

       public virtual ICollection<Tool_User> tool_users { get; set; } = new List<Tool_User>();

    }
}


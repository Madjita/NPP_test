using System;
using System.Collections.Generic;

namespace test_sql.EF_entities
{
    public class Tool : BaseEntity
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public virtual ICollection<Tool_User> tool_users { get; set; } = new List<Tool_User>();
    }
}


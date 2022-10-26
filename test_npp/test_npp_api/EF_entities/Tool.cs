using System;

namespace test_npp_api.EF_entities
{
    public class Tool : BaseEntity
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public virtual ICollection<Tool_User> tool_users { get; set; } = new List<Tool_User>();
        //public int Tool_UserId { get; set; }
        //public virtual Tool_User Tool_User { get;set;}
    }
}


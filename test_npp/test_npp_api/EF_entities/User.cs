using System;
namespace test_npp_api.EF_entities
{
    public class User : BaseEntity
    {
       public string FirstName { get; set; }

       public string LastName { get; set; }

       public string? MiddleName { get; set; }

        // public virtual ICollection<Tool> tools { get; set; } = new List<Tool>();
        public virtual ICollection<Tool_User> tool_users { get; set; } = new List<Tool_User>();

        //public int Tool_UserId { get; set; }
        //public virtual Tool_User Tool_User { get; set; }
    }
}


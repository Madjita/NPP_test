using System;
namespace test_sql.EF_entities
{
    public class Tool_User : BaseEntity
    {
        public int ToolId { get; set; }
        public virtual Tool Tool { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int GetCount { get; set; }

    }
}


using System;
using test_npp_api.EF_entities;

namespace test_npp_api.Models
{
    public class ToolUserModel
    {
        public int toolId { get; set; }

        public string toolName { get; set; }

        public int toolCount { get; set; }

        public int userId { get; set; }

        public string FIO { get; set; }
    }
}

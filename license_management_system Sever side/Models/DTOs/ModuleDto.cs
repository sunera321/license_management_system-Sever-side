﻿namespace license_management_system_Sever_side.Models.DTOs
{
    public class ModuleDto
    {
        public string ModuleName { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedData { get; set; }
        public string Features { get; set; }
        public string ModuleDescription { get; set; }
        public float ModuleCost { get; set; }
    }
}

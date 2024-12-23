using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryHub.Models.Entities
{
    public class AppSetting
    {
        public int Id { get; set; }
        public string SettingKey { get; set; }
        public string SettingName { get; set; }
    }
}
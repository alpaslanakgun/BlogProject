﻿using BlogProject.Entities.Concrete;
using System.Collections.Generic;

namespace BlogProject.Mvc.Areas.Admin.Models
{
    public class UserWithRolesViewModel
    {
        public User User { get; set; }
        public IList<string> Roles { get; set; }
    }
}

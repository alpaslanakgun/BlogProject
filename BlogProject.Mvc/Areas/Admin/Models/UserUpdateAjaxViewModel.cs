﻿using BlogProject.Entities.Dtos;

namespace BlogProject.Mvc.Areas.Admin.Models
{
    public class UserUpdateAjaxViewModel
    {
 
        public UserUpdateDto UserUpdateDto { get; set; }
        public string UserUpdatePartial { get; set; }
        public UserDto UserDto { get; set; }
    }
}

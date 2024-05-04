using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.User
{
    public class UserAddRequestDto
    {
        /// <summary>
        /// نام کاربر
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// نام خانوادگی کاربر
        /// </summary>
        public string LastName { get; set; }
    }
}

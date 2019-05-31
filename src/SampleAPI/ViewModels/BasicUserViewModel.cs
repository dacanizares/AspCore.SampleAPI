using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.ViewModels
{
    public class BasicUserViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}

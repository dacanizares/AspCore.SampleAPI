using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class UpdateUserCommand
    {
        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class CreateUserCommand
    {
        public string Username { get; set; }

        public string Email { get; set; }
    }
}

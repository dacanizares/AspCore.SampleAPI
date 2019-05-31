using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Commands
{
    public class UpdateUserCommand
    {
        public string Email { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}

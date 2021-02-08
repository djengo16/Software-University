using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUSACA.Data
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = new Guid().ToString();
        }
    }
}

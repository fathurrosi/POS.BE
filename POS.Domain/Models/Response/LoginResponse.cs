using POS.Domain.Entities;
using POS.Domain.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Models.Response
{
    public class LoginResponse<User> : ApiResult<User>
    {
        public List<Role> Roles { get; set; }

        public List<VUserPrevillage> Previllages { get; set; }
    }
}

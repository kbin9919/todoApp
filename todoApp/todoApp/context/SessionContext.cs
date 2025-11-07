using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoApp.login.vo;

namespace todoApp.context
{
    public static class SessionContext
    {
        public static UserVo? LoginUserSession { get; set; }
    }
}

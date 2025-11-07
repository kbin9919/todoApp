using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todoApp.login.verification
{
    public enum LoginChainResult
    {
        Success,
        DuplicateLogin,
        NotFoundUserData,
        NotFoundInputData,
        Fail,
        DBError,
    }
}

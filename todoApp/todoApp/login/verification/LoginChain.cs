using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todoApp.login.verification
{
    public delegate LoginChainResult LoginChain<LoginChainContext>(LoginChainContext context);
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static todoApp.login.verification.LoginChainResult;

namespace todoApp.login.verification
{
    public class LoginChainFactory
    {
        public List<LoginChain<LoginChainContext>> LoginVerification()
        {
            return new List<LoginChain<LoginChainContext>>
            {
                CheckId(),
                CheckPwd(),
            };
        }

        public LoginChain<LoginChainContext> CheckId()
        {
            return (context) =>
            {
                if (string.IsNullOrEmpty(context.InputId))
                {
                    return LoginChainResult.NotFoundInputData;
                }
                else if (string.IsNullOrEmpty(context.UserVo.Id))
                {
                    return LoginChainResult.NotFoundUserData;
                }
                else if (context.InputId != context.UserVo.Id)
                {
                    return LoginChainResult.Fail;
                }
                return LoginChainResult.Success;
            };
        }
        public LoginChain<LoginChainContext> CheckPwd()
        {
            return (context) =>
            {
                if (string.IsNullOrEmpty(context.InputPwd))
                {
                    return LoginChainResult.NotFoundInputData;
                }
                else if (string.IsNullOrEmpty(context.UserVo.Pwd))
                {
                    return LoginChainResult.NotFoundUserData;
                }
                else if (context.InputPwd != context.UserVo.Pwd)
                {
                    return LoginChainResult.Fail;
                }
                return LoginChainResult.Success;
            };
        }
    }
}

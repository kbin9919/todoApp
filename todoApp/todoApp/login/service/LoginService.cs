using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoApp.login.verification;
using todoApp.login.vo;
using todoApp.login.dao;

namespace todoApp.login.service
{
    public class LoginService
    {
        public LoginChainFactory LoginChainFactory;
        public LoginDao LoginDao;
        public LoginService()
        {
            LoginChainFactory = new LoginChainFactory();
            LoginDao = new LoginDao();
        }

        public LoginChainResult LoginVerification(UserVo inputUserVo)
        {
            UserVo vo = LoginDao.SelectUserVo(inputUserVo.Id);

            LoginChainContext context = new LoginChainContext()
            {
                UserVo = vo,
                InputId = inputUserVo.Id,
                InputPwd = inputUserVo.Pwd,
            };

            List<LoginChain<LoginChainContext>> chainResult = LoginChainFactory.LoginVerification();

            foreach (var chain in chainResult)
            {
                var result = chain(context);
                if (result != LoginChainResult.Success)
                {
                    return result;
                }
            }
            return LoginChainResult.Success;
        }


    }
}

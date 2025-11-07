using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todoApp.login.vo;

namespace todoApp.login.verification
{
    public class LoginChainContext
    {
        public UserVo UserVo { get; set; } // 실제 db에서 조회된 사용자 정보
        public string InputId { get; set; } // 사용자가 입력한 아이디
        public string InputPwd { get; set; } // 사용자가 입력한 비밀번호
    }
}

using todoApp.login.dto;
using todoApp.utill.SQL;

namespace todoApp.context
{
    public static class SessionContext
    {
        public static UserDto LoginUserSession { get; set; }
        public static SqlRapper SqlRapper { get; set; }

    }
}

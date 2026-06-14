using todoApp.context;
using todoApp.login.dto;
using todoApp.login.entity;

namespace todoApp.login.service
{
    public class LoginService
    {
        public LoginService()
        {
        }

        public UserDto LoginVerification(UserDto inputUser)
        {
            // 나중에 분리
            string sql = $"SELECT [Id],[Name],[Email],[Password],[CreatedAt],[DeletedAt],[DelYn] \r\nFROM [dbo].[User]\r\nWHERE [Id] = '{inputUser.Id}'";
            var user = SessionContext.SqlRapper.SelectOne<UserEntity>(sql);

            if (user == null)
            {
                return null;
            }

            if (inputUser.Password != user.Password)
            {
                return null;
            }

            return new UserDto() { Id = user.Id, Password = user.Password, Email = user.Email, Name = user.Name };
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using TemperatureMonitoring.CustomAuthorize;
using TemperatureMonitoring.Models;
using TemperatureMonitoring.Repository;

namespace TemperatureMonitoring.DataAccess
{
    public class CustomMembership : MembershipProvider
    {
        public override bool EnablePasswordRetrieval => throw new NotImplementedException();

        public override bool EnablePasswordReset => throw new NotImplementedException();

        public override bool RequiresQuestionAndAnswer => throw new NotImplementedException();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int MaxInvalidPasswordAttempts => throw new NotImplementedException();

        public override int PasswordAttemptWindow => throw new NotImplementedException();

        public override bool RequiresUniqueEmail => throw new NotImplementedException();

        public override MembershipPasswordFormat PasswordFormat => throw new NotImplementedException();

        public override int MinRequiredPasswordLength => throw new NotImplementedException();

        public override int MinRequiredNonAlphanumericCharacters => throw new NotImplementedException();

        public override string PasswordStrengthRegularExpression => throw new NotImplementedException();

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {

            UserLoginRepository _userLoginRepository = new UserLoginRepository();
            User _user = new User();
            List<UserRole> _userRoles = _userLoginRepository.GetUserRoles(username);
            if (_userRoles.Count>0)
            {
                _user.UserId = _userRoles[0].UserName;
                _user.Username = _userRoles[0].UserName;
                _user.Warehouse = _userRoles[0].Warehouse;
                _user.Roles = new List<Role>();
                foreach (var item in _userRoles)
                {
                    Role _role = new Role();
                    _role.RoleId = item.RoleId;
                    _role.RoleName = item.RoleName;
                   
                    _user.Roles.Add(_role);
                }
            }
           
            
            //_user.FirstName = "Minh Sang";
            //_user.LastName = "Nguyen";
           
            var selectedUser = new CustomMembershipUser(_user);
            return selectedUser;
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            UserLoginRepository _userLoginRepository = new UserLoginRepository();
            CUserLogin _cUserLogin =_userLoginRepository.GetUserLogin(username, password);
            if (_cUserLogin == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
            throw new NotImplementedException();
        }
    }
}

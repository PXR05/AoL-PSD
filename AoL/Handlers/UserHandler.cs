using AoL.Factories;
using AoL.Models;
using AoL.Repo;

namespace AoL.Handlers {
    public class UserHandler {
        private static string ValidateInfo(string username, string email, string dob, string gender) {
            return username == "" || email == "" || gender == "" || dob == ""
                ? "All fields must be filled!"
                : username.Length < 5
                ? "Username must be at least 5 characters long!"
                : username.Length > 15
                ? "Username must be at most 15 characters long!"
                : !email.EndsWith(".com") ? "Email must be a valid format!" : "";
        }

        private static string ValidatePassword(string password, string conf) {
            return password == "" || conf == "" ? "All fields must be filled!" : password != conf ? "Passwords do not match!" : "";
        }

        private readonly UserFactory _userFactory = new UserFactory();
        private readonly UserRepo _userRepo = new UserRepo();

        public string RegisterUser(string username, string email, string password, string conf, string dob,
            string gender) {

            var infoError = ValidateInfo(username, email, dob, gender);
            if (infoError != "") {
                return infoError;
            }
            var passwordError = ValidatePassword(password, conf);
            if (passwordError != "") {
                return passwordError;
            }

            var user = _userFactory.CreateUser(username, email, password, gender, dob);
            _userRepo.AddUser(user);

            return "";
        }

        public (string, User) LoginUser(string username, string password) {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
                return ("Please fill all fields!", null);
            }
            var user = _userRepo.GetUser(username, password);

            return user == null ? ("Invalid username or password!", null) : ("", user);
        }

        public (string, User) CookieLogin()

        public (string, User) UpdateUser(int id, string username, string email, string gender, string dob) {
            var infoError = ValidateInfo(username, email, dob, gender);
            if (infoError != "") {
                return (infoError, null);
            }

            var (updateError, user) = _userRepo.UpdateUser(id, username, email, gender, dob);

            return updateError != "" ? (updateError, null) : ("", user);
        }
    }
}
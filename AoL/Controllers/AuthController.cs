using AoL.Handlers;

namespace AoL.Controllers {
    public class AuthController {
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

        private static string ValidatePassword(string password) {
            return password == null ? "Password must not be empty!" : password == "" ? "Password must not be empty!" : "";
        }

        private static string ValidateUsername(string username) {
            return username == null
                ? "Username must not be empty!"
                : username == "" ? "Username must not be empty!" : username.Length < 5 ? "Username must be at least 5 characters long!" : username.Length > 15 ? "Username must be at most 15 characters long!" : "";
        }

        public static string RegisterUser(string username, string email, string password, string confPassword,
            string dob, string gender) {
            var infoError = ValidateInfo(username, email, dob, gender);
            if (infoError != "") return infoError;
            var passwordError = ValidatePassword(password, confPassword);
            if (passwordError != "") return passwordError;
            var error = AuthHandler.RegisterUser(username, email, password, dob, gender);
            return error;
        }

        public static string SessionLogin(string id) {
            var error = AuthHandler.SessionLogin(id);
            return error;
        }

        public static string LoginUser(string username, string password) {
            var usernameError = ValidateUsername(username);
            if (usernameError != "") return usernameError;
            var passwordError = ValidatePassword(password);
            if (passwordError != "") return passwordError;
            var error = AuthHandler.LoginUser(username, password);
            return error;
        }

        public static string UpdateUser(int id, string username, string email, string gender, string dob) {
            var infoError = ValidateInfo(username, email, dob, gender);
            if (infoError != "") return infoError;
            var error = AuthHandler.UpdateUser(id, username, email, gender, dob);
            return error;
        }

        public static string UpdatePassword(int id, string oldPass, string newPass) {
            var oldPassError = ValidatePassword(oldPass);
            if (oldPassError != "") return oldPassError;
            var newPassError = ValidatePassword(newPass);
            if (newPassError != "") return newPassError;
            var error = AuthHandler.UpdatePassword(id, oldPass, newPass);
            return error;
        }
    }
}
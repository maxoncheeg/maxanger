namespace Maxanger.Api.Controllers.Routes;

public static class MaxangerRoutes
{
    public const string Api = "/api/v{version:apiVersion}";

    public static class Test
    {
        public const string Base = Api + "/test";
        public const string HelloWorld = Api + "/helloworld";
        public const string GetRandomNumber = Base + "/randomnum";
        public const string GetCurrentDate = Base + "/date";
        public const string GetAgeByYear = Base + "/age/{year}";
        public const string GetTestTrucks = Base + "/trucks";
        public const string GetTestTruckById = GetTestTrucks + "/{id}";
        public const string CreateTestTruck = Base + "/trucks";
        public const string SendTestMail = Base + "/mail";
        
        public const string AdminOnly = Base + "/admin";
        public const string VerifiedEmailOnly = Base + "/email";
        public const string ExternalUserOnly = Base + "/external";
        public const string CompleteExternalUserOnly = Base + "/external/complete";
    }

    public static class Chat
    {
        public const string Base = Api + "/chat";
        public const string SendMessage = Base + "/send";
        public const string WhisperMessage = Base + "/whisper";
        public const string Create = Base + "/create";
        public const string Hub = Base + "/hub";
    }

    public static class Auth
    {
        public const string Base = Api + "/auth";
        public const string Login = Base + "/login";
        public const string Register = Base + "/register";
        public const string ConfirmRegisterWithCode = Register + "/code";
        public const string ChangePassword = Base + "/password";
        public const string ConfirmPasswordWithCode = ChangePassword + "/code";
        public const string Logout = Base + "/logout";
        public const string LoginByToken = Base + "/token/login";
        public const string RefreshToken = Base + "/token/refresh";

        public static class OAuth
        {
            public const string Base = Api + "/oauth";
            public const string Provider = Base + "/{provider}";
            public static string Callback(string provider) => $"{Base}/login/{provider}";
            public const string Authorize = Base + "/authorize";
            public const string Register = Base + "/register";
        }
    }

}
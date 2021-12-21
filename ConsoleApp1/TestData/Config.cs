using ConsoleApp1.BaseApp;

namespace ConsoleApp1
{
    public static class Config
    {
        public static string BaseURL = "https://testing.todorvachev.com/";

        public static class Credentials
        {
            public enum selectContry { Australia, Canada, India, Russia, USA };
            public static class Valid
            {
                public static string userName = "ValidUser";
                public static string password = "abcd!1234";
                public static string repeatPassword = "abcd!1234";
                public static string email = "karthik2991@gmail.com";
                public static string name = "karthik";
                public static string address = "Mangadu";
                public static string country = selectContry.USA.ToString();
                public static string zipCode = "600122";
                public static string Sex = "Male";
                public static string About = "This is for my selenium testing training";
            }

            public static class Invalid
            {
                public static class UserName
                {
                    public static string threeLettersUserName = "qba";
                    public static string thirteenLetterUserName = "qaseftgyhujiko";
                }

                public static class Password
                {

                }
            }
        }

        public static class BrowserDetails
        {
            public static string browserType = "Chrome";
        }

        public static class FileDetails
        {
            public static string FolderLocation = "D:\\karthikLearning\\screeshot";
        }
           
    }
}

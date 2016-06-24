using APP.CRM.Mail;

namespace APP.CRM
{
    /// <summary>
    /// Clasa w której są zapisane dane po zalogowaniu
    /// </summary>
    public class cSession
    {
        public static string login;//login zalogowanego uzytkownika
        public static string passwordUser;//haslo zalogowanego uzytkownika(do maili)
        public static int userId;//id uzytkownika zalogowanego
        public static cMailBox inbox;//polaczenie do poczty 
        public static string tempPath;//sciezka tymczasowa
    }
}

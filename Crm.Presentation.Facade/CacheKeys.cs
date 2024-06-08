namespace Crm.Presentation.Facade
{
    class CacheKeys
    {
        public static string User(long id) => $"user-{id}";
        public static string UserToken(string token) => $"tokne-{token}";
    }
}

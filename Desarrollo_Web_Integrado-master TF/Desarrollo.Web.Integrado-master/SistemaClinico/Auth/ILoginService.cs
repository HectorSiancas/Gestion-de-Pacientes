namespace SistemaClinico.Auth
{
    public interface ILoginService
    {
        Task Login(UserToken userToken);
        Task Logout();
        Task ManejarRenovacionToken();
    }

    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        //public DateTime Expedicion  { get; set; }
        public double ExpiracionMinutos { get; set; }

        public string EncrypDeviceId { get; set; }

        public string? PublicKey { get; set; }

        public bool Requiere2FA { get; set; }
    }
}

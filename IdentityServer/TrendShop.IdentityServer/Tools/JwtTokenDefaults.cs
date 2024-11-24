namespace TrendShop.IdentityServer.Tools
{
    public class JwtTokenDefaults
    {
        // tokenı kimin yayınladığını ifade eder.
        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer = "http://localhost"; // Yayınlayıcı
        public const string Key = "TrendShop..0102030405Asp.NetCore6.0.28*/+-";
        public const int Expire = 1;
    }
}

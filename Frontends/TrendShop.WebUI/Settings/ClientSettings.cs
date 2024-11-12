namespace TrendShop.WebUI.Settings
{
    public class ClientSettings
    {
        public Client TrendShopVisitorClient { get; set; }
        public Client TrendShopManagerClient { get; set; }
        public Client TrendShopAdminClient { get; set; }
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}

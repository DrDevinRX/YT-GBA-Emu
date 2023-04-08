using YouTube.Base;
using YouTube.Base.Clients;

namespace GBA
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<OAuthClientScopeEnum> scopes = new()
            {
                OAuthClientScopeEnum.ReadOnlyAccount
            };

            string? clientId = System.Environment.GetEnvironmentVariable("YT_CID");
            string? clientSecret = System.Environment.GetEnvironmentVariable("YT_CS");

            if (clientId is null && clientSecret is null)
            {
                Console.WriteLine("Bad client id or client secret");
                Environment.Exit(1);
            }

            YouTubeConnection youTubeConnection = await YouTubeConnection.ConnectViaLocalhostOAuthBrowser(clientId, clientSecret, scopes);

            Console.WriteLine(youTubeConnection.ToString());
        }
    }
}
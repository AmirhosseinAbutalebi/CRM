using UAParser;
namespace WebApi.Common.GetDevice
{
    public static class GetUserDevice
    {
        public static string DeviceName(string uaString)
        {
            var info = Parser.GetDefault();
            ClientInfo client = info.Parse(uaString);

            var device = $"{client.Device.Family} / {client.OS.Family} {client.OS.Major} {client.OS.Minor} /" +
                         $" {client.UA.Family} {client.UA.Major}.{client.UA.Minor}";
            return device;
        }
    }
}

using System.Collections.Generic;
using ActionInUkraine.Web.Implementations.Authentication;
using Microsoft.Web.WebPages.OAuth;

namespace ActionInUkraine.Web.App_Start
{
  public static class AuthConfig
  {
    public static void RegisterAuth()
    {
      // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
      // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166
      RegisterFBClient();
      RegisterVKClient();
      RegisterGoogleClient();
    }
    private static void RegisterMSClient()
    {
      OAuthWebSecurity.RegisterMicrosoftClient(
        clientId: "",
        clientSecret: "");
    }
    private static void RegisterVKClient()
    {
      OAuthWebSecurity.RegisterClient(
        client: new VkClient("3948805", "1n05UUgdQBPXPNvrUBpj"),
        displayName: "ВКонтактi",
        extraData: new Dictionary<string, object>()
          {
            {"iconUrl", "Images/vkontakte_icon.gif"}
          });
    }
    private static void RegisterFBClient()
    {
      OAuthWebSecurity.RegisterFacebookClient(
        appId: "1401007186800972",
        appSecret: "b6c03f4723dcc7a484954daa8db3bb68",
        displayName: "Facebook",
        extraData: new Dictionary<string, object>()
          {
            {"iconUrl", "Images/facebook_icon.gif"}
          });
    }
    private static void RegisterTweeterClient()
    {
      OAuthWebSecurity.RegisterTwitterClient(
        consumerKey: "",
        consumerSecret: "");
    }
    private static void RegisterGoogleClient()
    {
      OAuthWebSecurity.RegisterGoogleClient();
    }
  }
}
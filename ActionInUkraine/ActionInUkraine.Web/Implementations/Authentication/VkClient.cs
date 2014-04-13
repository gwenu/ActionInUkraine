using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using DotNetOpenAuth.AspNet;

namespace ActionInUkraine.Web.Implementations.Authentication
{
  public class VkClient : IAuthenticationClient
  {
    private readonly string m_appId;
    private readonly string m_appSecret;
    private string m_redirectUri;

    public VkClient(string appId, string appSecret)
    {
      m_appId = appId;
      m_appSecret = appSecret;
    }

    string IAuthenticationClient.ProviderName
    {
      get
      {
        return "vkontakte";
      }
    }
    
    void IAuthenticationClient.RequestAuthentication(
                            HttpContextBase context, Uri returnUrl)
    {
      var appID = m_appId;
      m_redirectUri = context.Server.UrlEncode(returnUrl.ToString());
      var address = string.Format("https://oauth.vk.com/authorize?client_id={0}&redirect_uri={1}&response_type=code",
        appID, m_redirectUri);

      HttpContext.Current.Response.Redirect(address, false);
    }

    class AccessToken
    {
      public string access_token = null;
      public string user_id = null;
    }

    class UserData
    {
      public string uid = null;
      public string first_name = null;
      public string last_name = null;
      public string photo_50 = null;
    }

    class UsersData
    {
      public UserData[] response = null;
    }

    AuthenticationResult IAuthenticationClient.VerifyAuthentication(HttpContextBase context)
    {
      try
      {
        string code = context.Request["code"];

        var address = String.Format(
                "https://oauth.vk.com/access_token?client_id={0}&client_secret={1}&code={2}&redirect_uri={3}",
                m_appId, m_appSecret, code, m_redirectUri);

        var response = Load(address);
        var accessToken = DeserializeJson<AccessToken>(response);

        address = String.Format("https://api.vk.com/method/users.get?uids={0}&fields=photo_50", accessToken.user_id);

        response = Load(address);
        var usersData = DeserializeJson<UsersData>(response);
        var userData = usersData.response.First();

        return new AuthenticationResult(
            true, (this as IAuthenticationClient).ProviderName, accessToken.user_id,
            userData.first_name + " " + userData.last_name,
            new Dictionary<string, string>());
      }
      catch (Exception ex)
      {
        return new AuthenticationResult(ex);
      }
    }

    private static string Load(string address)
    {
      var request = WebRequest.Create(address) as HttpWebRequest;

      using (var response = request.GetResponse() as HttpWebResponse)
      {
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
          return reader.ReadToEnd();
        }
      }
    }
    private static T DeserializeJson<T>(string input)
    {
      var serializer = new JavaScriptSerializer();
      return serializer.Deserialize<T>(input);
    }
  }
}
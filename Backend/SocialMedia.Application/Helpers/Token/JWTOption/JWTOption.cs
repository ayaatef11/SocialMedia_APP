namespace SocialMedia.Application.Helpers.Token.JWTOptions;
public class JWTOption
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
    public string ExpireTime { get; set; }
}


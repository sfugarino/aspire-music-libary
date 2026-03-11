namespace MusicLibrary.Domain.Config;

public class KeycloakSettings
{
    /// <summary>
    /// Gets or sets the Keycloak base URL.
    /// </summary>
    public string BaseUrl { get; set; } = null!;
    /// <summary>
    /// Gets or sets the Keycloak realm.
    /// </summary>
    public string Realm { get; set; } = null!;
    /// <summary>
    /// Gets or sets the Keycloak client ID.
    /// </summary>
    public string ClientId { get; set; } = null!;
    /// <summary>
    /// Gets or sets the Keycloak authorization URL.
    /// </summary>
    public string AuthorizationUrl { get; set; } = null!;
    /// <summary>
    /// Gets or sets the Keycloak token URL.
    /// </summary>
    public string TokenUrl { get; set; } = null!;
    /// <summary>
    /// Gets or sets the Keycloak username.
    /// </summary>
    public string Username { get; set; } = null!;
    /// <summary>
    /// Gets or sets the Keycloak password.
    /// </summary>
    public string Password { get; set; } = null!;
    /// <summary>
    /// Gets or sets the Keycloak grant type.
    /// </summary>
    public string GrantType { get; set; } = null!;
    /// <summary>
    /// Gets or sets the Keycloak client secret.
    /// </summary>
    public string ClientSecret { get; set; } = null!;
}
namespace Altairis.TrailingSlashMiddleware;

public enum TrailingSlashMiddlewareMode {
    Remove,
    Add
}

public class TrailingSlashMiddlewareOptions {

    public TrailingSlashMiddlewareMode Mode { get; set; } = TrailingSlashMiddlewareMode.Remove;

    public bool PermanentRedirect { get; set; } = true;

    public bool PreserveMethod { get; set; } = true;

}

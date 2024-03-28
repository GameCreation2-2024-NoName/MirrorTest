using Mirror;

public class Ball : NetworkBehaviour
{
    public override void OnStartServer()
    {
        Invoke(nameof(DestroySelf), 2f);
    }
    [Server]
    private void DestroySelf() => NetworkServer.Destroy(gameObject);
}
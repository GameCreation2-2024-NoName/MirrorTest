using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    [Header("My")]
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [SerializeField] [ReadOnly] private int playerCount = 0;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        if (playerCount > 1) return;

        var playerObj = playerCount == 0 ? player1 : player2;
        playerCount++;

        var startPos = GetStartPosition();
        var player = startPos != null
            ? Instantiate(playerObj, startPos.position, startPos.rotation)
            : Instantiate(playerObj);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
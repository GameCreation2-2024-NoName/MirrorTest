using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private GameObject spawnObj;

    private void Update()
    {
        if (!isLocalPlayer) return;

        var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        transform.position += input * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)) CmdSpawn();
    }

    [Command]
    private void CmdSpawn()
    {
        var obj = Instantiate(spawnObj, transform.position, Quaternion.identity);
        NetworkServer.Spawn(obj);
        ClientDebug();
    }

    [ClientRpc]
    private void ClientDebug()
    {
        Debug.Log($"{gameObject.name} spawned an object!");
    }
}

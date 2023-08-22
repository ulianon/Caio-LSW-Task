using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public static GameManager instance;

    [Header("UI Manager Ref")]
    public UIManager UIManagerInstance;


    [Header("CurrentPlayer")]
    Player currentPlayerSingle; public Player CurrentPlayerSingle() => currentPlayerSingle;


    private void Awake()
    {
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    //Network regions
    public void MyStartClient()
    {
        NetworkManager.Singleton.StartClient();
        currentPlayerSingle = NetworkManager.Singleton.ConnectedClients[this.NetworkManager.LocalClientId].PlayerObject.GetComponent<Player>();
        UIManagerInstance.OpenGameCanvas();
    }

    public void MyStartHost()
    {
        NetworkManager.Singleton.StartHost();
        currentPlayerSingle = NetworkManager.Singleton.ConnectedClients[0].PlayerObject.GetComponent<Player>();
        UIManagerInstance.OpenGameCanvas();
    }
}

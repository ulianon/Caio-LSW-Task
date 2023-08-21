using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameManager : NetworkBehaviour
{
    public static GameManager Instance;


    public Canvas currentCanvas;

    private void Awake()
    {
        if (Instance == null) Instance = this;
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
        currentCanvas.enabled = false;
    }

    public void MyStartHost()
    {
        NetworkManager.Singleton.StartHost();
        currentCanvas.enabled = false;
    }
}

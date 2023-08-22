using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button interactItemButton;
    [SerializeField] Canvas gameCanvas;
    [SerializeField] Canvas lobbyCanvas;
    [SerializeField] Canvas worldCanvas;
    Canvas currentCanvas; public Canvas CurrentCanvas() => currentCanvas;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    IInteractable currentItemSelected;
    public void InteractItemButtonActive(IInteractable _item, Vector3 _interactPosition)
    {
        interactItemButton.gameObject.SetActive(true);
        interactItemButton.transform.GetComponentInParent<Canvas>().worldCamera = Camera.main;
        interactItemButton.transform.position = Camera.main.WorldToViewportPoint(_interactPosition);

        //Places it up a little higher over the object
        interactItemButton.transform.position += new Vector3(_interactPosition.x, 2, 0);

        //Temporary checks for current item interaction
        currentItemSelected = _item;
    }

    public void ItemButtonClicked()
    {
        interactItemButton.enabled = false;
        currentItemSelected.Interact();
    }

    public void OpenGameCanvas()
    {
        lobbyCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
        worldCanvas.gameObject.SetActive(true);
        currentCanvas = gameCanvas;
    }
}

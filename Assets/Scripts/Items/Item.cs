using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [Header("ItemProperties")]
    [SerializeField] int cost;

    enum Type
    {
        Cloth,
        Consumable,
        Weapon
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        Debug.Log("aeeei");

        GameManager.instance.CurrentPlayerSingle().ChangeClothes(gameObject);
    }

}

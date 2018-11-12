using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class ResourcePickup : MonoBehaviour {
    PlayerInventory player_inventory;

    private void Start()
    {
        player_inventory = GetComponent<PlayerInventory>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Resource")
        {
            player_inventory.OnResourcePickUp(other.GetComponent<Resource>());
            GameObject.Destroy(other.gameObject);
        }
    }
}

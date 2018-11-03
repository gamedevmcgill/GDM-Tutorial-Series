using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInventory))]
public class ResourcePickup : MonoBehaviour {
    PlayerInventory player_inventory;

	void Start () {
        player_inventory = GetComponent<PlayerInventory>();
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Resource") OnResourceHit(other.GetComponent<Resource>());
    }

    public void OnResourceHit(Resource resource)
    {
        player_inventory.OnResourcePickUp(resource);
        GameObject.Destroy(resource.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    private Dictionary<string, int> resource_count_map;

    private void Start()
    {
        resource_count_map = new Dictionary<string, int>();
    }

    // Check if we're able to spawn the block given
    public bool HasResource(string resource_id)
    {
        return resource_count_map.ContainsKey(resource_id);
    }

    public void OnResourcePickUp(Resource resource)
    {
        string id = resource.resource_id;
        if (!resource_count_map.ContainsKey(id)) resource_count_map[id] = 0;

        resource_count_map[id]++;

        LogResourceCountMap();
    }

    public void OnResourceUse(string resource_id)
    {
        if(!HasResource(resource_id))
        {
            Debug.Log("OnBlockSpawn called when unable to spawn block (not enough resources!)");
            return;
        }

        resource_count_map[resource_id]--;
        LogResourceCountMap();

        if (resource_count_map[resource_id] == 0) resource_count_map.Remove(resource_id);

    }

    public void LogResourceCountMap()
    {
        foreach(KeyValuePair<string, int> entry in resource_count_map)
        {
            Debug.Log(entry.Key + " " + entry.Value);
        }
    }
}

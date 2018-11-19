using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    private static BlockManager pInstance = null;
    public List<Block> blockPrefabList;

    // Map to query prefabs based on resource required to spawn
    private Dictionary<string, Block> resource_to_block;
    // Map to query blocks spawned based on world position
    private Dictionary<Vector3, Block> blockList;
    [SerializeField]
    public IBlockSpawner blockSpawner;

    public void Awake()
    {
        if (pInstance == null) pInstance = this;
        else Destroy(this);
    }

    public static BlockManager getInstance() { return pInstance; }

    public void Start()
    {
        //blockSpawner = GetComponent<IBlockSpawner>();
        List<Block> spawned_blocks = blockSpawner.SpawnBlocks();

        resource_to_block = new Dictionary<string, Block>();
        foreach (Block b in blockPrefabList)
        {
            if (resource_to_block.ContainsKey(b.resource_id)) Debug.LogError("Multiple prefab blocks detected with same ressource id");
            resource_to_block[b.resource_id] = b;
        }

        blockList = new Dictionary<Vector3, Block>();
        foreach (Block b in spawned_blocks)
        {
            b.tag = "Block";
            blockList[b.transform.position] = b;
            b.grid_position = b.transform.position;
        }
    }

    public bool AddBlock(string resource_id, Vector3 position)
    {
        if (blockList.ContainsKey(position))
        {
            Debug.LogError("Tried to add block in existing block location");
            return false;
        }
        if(!resource_to_block.ContainsKey(resource_id))
        {
            Debug.LogError("No matching block found for given resource id " + resource_id);
            return false;
        }

        blockList[position] = GameObject.Instantiate(resource_to_block[resource_id], position, Quaternion.identity) as Block;
        return true;
    }

    public bool RemoveBlock(Vector3 position)
    {
        if(!blockList.ContainsKey(position))
        {
            Debug.LogError("No block found at position " + position.ToString() + " to remove ");
            return false;
        }

        Destroy(blockList[position].gameObject);
        blockList.Remove(position);
        return true;
    }
}

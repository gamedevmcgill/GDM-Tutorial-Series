using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    private static BlockManager pInstance = null;
    public List<Block> blockPrefabList;

    private List<Block> blockList;
    private IBlockSpawner blockSpawner;

    public void Awake()
    {
        if (pInstance == null) pInstance = this;
        else Destroy(this);
    }

    public BlockManager getInstance() { return pInstance; }

    public void Start()
    {
        blockSpawner = GetComponent<IBlockSpawner>();
        blockList = blockSpawner.SpawnBlocks();
    }
}

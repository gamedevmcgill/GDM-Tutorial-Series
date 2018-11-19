using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBlockSpawner : MonoBehaviour {
    public abstract List<Block> SpawnBlocks();
}

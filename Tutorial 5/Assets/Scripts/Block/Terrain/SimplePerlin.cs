using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePerlin : IBlockSpawner
{
    public int width;
    public int height;
    public float zoom;
    public float holeProbability;
    public Vector3 startPoint;
    public Block blockPrefab;

    public override List<Block> SpawnBlocks()
    {
        List<Block> spawned_blocks = new List<Block>();
        for (int r = 0; r < width; r++)
        {
            for (int c = 0; c < height; c++)
            {
                float rand = Mathf.PerlinNoise(r*zoom/width, c*zoom/height);
                if (rand <= holeProbability) continue;

                float x = (float)r * blockPrefab.transform.localScale.x;
                float z = (float)c * blockPrefab.transform.localScale.z;

                Block block = GameObject.Instantiate(blockPrefab, startPoint + new Vector3(x, 0, z), Quaternion.identity) as Block;
                spawned_blocks.Add(block);
            }
        }

        return spawned_blocks;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

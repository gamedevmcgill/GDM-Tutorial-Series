using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uniform2dSpawner : IBlockSpawner {
    public int width;
    public int height;
    public float holeProbability;
    public Vector3 startPoint;
    public Block blockPrefab;

    public Uniform2dSpawner(int w, int h, float p, Block block)
    {
        width = w;
        height = h;
        holeProbability = p;
        blockPrefab = block;
    }

    public override List<Block> SpawnBlocks()
    {
        List<Block> spawned_blocks = new List<Block>();
        for (int r = 0; r < width; r++)
        {
            for (int c = 0; c < height; c++)
            {
                float rand = Random.RandomRange(0.0f, 1.0f);
                if (rand <= holeProbability) continue;

                float x = (float)r * blockPrefab.transform.localScale.x;
                float z = (float)c * blockPrefab.transform.localScale.z;

                Block block = GameObject.Instantiate(blockPrefab, startPoint + new Vector3(x, 0, z), Quaternion.identity) as Block;
                spawned_blocks.Add(block);
            }
        }

        return spawned_blocks;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinHeight : IBlockSpawner {

    public int width;
    public int length;
    public float max_height;
    public float zoom;
    public Vector3 startPoint;
    public Block blockPrefab;

    public override List<Block> SpawnBlocks()
    {
        List<Block> spawned_blocks = new List<Block>();
        for (int r = 0; r < width; r++)
        {
            for (int c = 0; c < length; c++)
            {
                float blockHeight = GetPerlin(r,c) * max_height;

                float x = (float)r * blockPrefab.transform.localScale.x;
                float z = (float)c * blockPrefab.transform.localScale.z;
                    
                Block block = GameObject.Instantiate(blockPrefab, startPoint + new Vector3(x, blockHeight*0.5f, z), Quaternion.identity) as Block;
                block.gameObject.transform.localScale = (new Vector3(blockPrefab.transform.localScale.x, blockPrefab.transform.localScale.y * blockHeight, blockPrefab.transform.localScale.z));
                spawned_blocks.Add(block);
            }
        }

        return spawned_blocks;
    }

    float GetPerlin(int r, int c)
    {
        return Mathf.PerlinNoise(r * zoom / width, c * zoom / length);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

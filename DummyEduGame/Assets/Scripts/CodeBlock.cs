using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlock : MonoBehaviour
{
    [SerializeField]
    private List<Block> blocks;
    [SerializeField]
    private float readDistance;
    [SerializeField]
    private float readTime;
    [SerializeField]
    private float readVelocity;

    public void ReadValues()
    {
        //JUST FOR TESTS, PLEASE DELETE LATER
        blocks.Add(new Block(BlockType.velocity, 10.0f));
        
        foreach(Block block in blocks) 
        {
            switch (block.GetBlockType()) 
            {
                case BlockType.distance:
                    this.readDistance = block.GetValue();
                    break;
                case BlockType.time:
                    this.readTime = block.GetValue();
                    break;
                case BlockType.velocity:
                    this.readVelocity = block.GetValue();
                    break;
            }
        }
    }

    public float GetDistance()
    {
        return this.readDistance;
    }

    public float GetTime()
    {
        return this.readDistance;
    }

    public float GetVelocity()
    {
        return this.readVelocity;
    }
}
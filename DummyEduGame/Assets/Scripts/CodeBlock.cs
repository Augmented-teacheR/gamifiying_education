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

    public void AddBlock(Block block)
    {
        blocks.Add(block);
    }

    public void RemoveBlock(Block block)
    {
        blocks.Remove(block);
    }

    public float GetDistance()
    {
        return this.readDistance;
    }

    public float GetTime()
    {
        return this.readTime;
    }

    public float GetVelocity()
    {
        return this.readVelocity;
    }
}
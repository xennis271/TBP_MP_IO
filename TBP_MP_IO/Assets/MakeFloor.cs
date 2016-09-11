using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class MakeFloor : MonoBehaviour {

    // Use this for initialization
    [Header("DevBlock")]
    public Material Dev;
    [Header("Map Stuff")]
    public int AmountOfBlocksToBeMade;
    public int HowFarX;
    public int MaxHight;
    public int HowFarZ;
    public int Layers;
    [Header("Blocks")]
    public List<Material> BlockTypes;
    [Header("Made Stats.")]
    public int MadeX;
    public int MadeY;
    public int MadeZ;
    public int AmountOfBlocksMade;
    public int Way;
    public int Fill;

    void Start ()
    {
        GameObject Block = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Block.transform.Translate(0, 0, 0); // move the block to the right place
    }
   



    void Update () {
        // lets make the world
        int Rand = Random.Range(5, 8);
        
        if (Rand == 5)
        {
            MadeX = MadeX + 1;
            Debug.Log("Added to X");
        }
        if (Rand == 7)
        {
            MadeY = MadeY + 1;
            Debug.Log("Added to Y");
        }
        if (Rand == 99999) // dont call
        {
            MadeZ = MadeZ + 1;
            Debug.Log("Added to Z");
        }
        if (MadeY > MaxHight)
        {
            Debug.Log(MadeY+" > "+MaxHight);
            MadeY = 0;
            Debug.Log("Grew to high");
        }
        if (MadeX > HowFarX)
        {
            MadeX = HowFarX;
        }
        if (MadeZ > HowFarZ)
        {
            MadeZ = Layers;
        }
        if (AmountOfBlocksMade < AmountOfBlocksToBeMade)
        {
            AmountOfBlocksMade++;
            // lets make that block...
            GameObject Block = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Block.transform.Translate(MadeX,MadeY,MadeZ); // move the block to the right place
            Renderer Rend = Block.GetComponent<Renderer>();
            Rend.material = BlockTypes[Random.Range(0, BlockTypes.Count)]; // make the block look right
            Block.name = Rend.material.name;
            Fill = MadeY;
        }
        else
        {
            if (Layers > 0)
            {
                MadeX = 0;
                MadeY = 0;
                MadeZ = MadeZ + 1;
                AmountOfBlocksMade = 0;
                Layers--;
            }
        }
        if (MadeY > 0) // we are above the ground and thus must fill that space...
        {
            
            while (Fill > 0)
            {
                Fill = Fill - 1; // keep filling...
                GameObject Filler = GameObject.CreatePrimitive(PrimitiveType.Cube); // make a filler block...
                Filler.transform.Translate(MadeX, Fill, MadeZ); // move the block to the right place
                Renderer FillRend = Filler.GetComponent<Renderer>();
                FillRend.material = Dev;
                Filler.name = FillRend.material.name;

            }

        }
    }
    }

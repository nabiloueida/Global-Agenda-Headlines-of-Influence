using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipManager : MonoBehaviour
{

    public int[,] relationshipGrid;

    // Start is called before the first frame update
    void Start()
    {
        relationshipGrid = new int[7, 7];
        generateRelationships();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateRelationships()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                int rand = Random.Range(10, 91);
                if (i != j)
                {
                    relationshipGrid[i , j] = rand;
                    relationshipGrid[j, i] = relationshipGrid[i, j];
                }
                else
                {
                    relationshipGrid[i,j] = -1;
                    
                }
                //SpawnTiles(i, j, relationshipGrid[i, j]);
            }
        }
    }

    private void SpawnTiles(int x, int y, int value)
    {
        GameObject g = new GameObject("X: "+ x + "Y: " + y);
        g.transform.position = new Vector3(x, y);
    }
}

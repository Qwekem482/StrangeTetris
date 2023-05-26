using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private GameObject[] groups;
    [SerializeField]private Sprite[] sprites;
    public static int nextBlock = 0;

    void Start() 
    {
        GenerateNext();
        Spawn();
    }

    public void Spawn() 
    {
        GameObject newBlock = Instantiate(groups[nextBlock], transform.position, Quaternion.identity);

        for(int i = 0; i < newBlock.transform.childCount; i++)
        {
            newBlock.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = sprites[nextBlock];
        }
        
        GenerateNext();
    }

    private void GenerateNext()
    {
        nextBlock = Random.Range(0, groups.Length);
    }
}

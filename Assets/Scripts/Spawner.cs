using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private GameObject[] groups;
    public static int nextBlock = 0;

    void Start() 
    {
        GenerateNext();
        Spawn();
    }

    public void Spawn() 
    {
        Instantiate(groups[nextBlock], transform.position, Quaternion.identity);
        GenerateNext();
    }

    private void GenerateNext()
    {
        nextBlock = Random.Range(0, groups.Length);
    }
}

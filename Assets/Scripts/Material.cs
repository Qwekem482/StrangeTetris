using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material : MonoBehaviour
{
    void Update()
    {
        if(!GameBoard.IsInBoard(transform.position)) GetComponent<SpriteRenderer>().enabled = false;
        else GetComponent<SpriteRenderer>().enabled = true;
    }
}

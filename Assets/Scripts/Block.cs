using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GameBoard;

public class Block : MonoBehaviour
{
    private float lastFall = 0;
    private bool drop = false;
    public static bool isGameOver = false;

//Improve Code DONE
//Improve GameOver mechanism DONE
//Improve Spawn Block mechanism DONE
//Improve Rotate mechanism
//Fix bug Rotate in try block (to remove try block)
//Add Drop DONE
//Add Score
//Add Local High Score (Optional)
//Add Timer
//Add UI
//Add Start & GameOver scene
//Change Falling mechanism (Optional)
    void Start() 
    {
        if (!IsValidPosition()) 
        {
            isGameOver = true;
            Destroy(gameObject);
        }
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) HorizontalMove(new Vector3(-1, 0, 0));

        if (Input.GetKeyDown(KeyCode.RightArrow)) HorizontalMove(new Vector3(1, 0, 0));

        if(Input.GetKeyDown(KeyCode.DownArrow)) drop = true;

        if(Input.GetKey(KeyCode.DownArrow) && drop) Drop();

        if (Time.time - lastFall >= 1) 
        {
            Drop();

            lastFall = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            transform.Rotate(0, 0, -90);
       
            if (IsValidPosition()) UpdateBoard();
            else transform.Rotate(0, 0, 90);
        }
    }

    private void Drop()
    {
        transform.position += new Vector3(0, -1, 0);

        if (IsValidPosition()) UpdateBoard();
        else 
        {
            transform.position += new Vector3(0, 1, 0);

            DeleteFullRows();
            FindObjectOfType<Spawner>().Spawn();

            enabled = false;
        }
    }


    private void HorizontalMove(Vector3 direction)
    {
        transform.position += direction;

        if (IsValidPosition()) UpdateBoard();
        else transform.position -= direction;
    }

    private bool IsValidPosition() 
    {        
        foreach (Transform child in transform) 
        {
            Vector2 vector = RoundVector2(child.position);

            if (!IsInside(vector)) return false;

            if (board[(int)vector.x, (int)vector.y] != null && board[(int)vector.x, (int)vector.y].parent != transform) return false;

            /*try
            {
                if (board[(int)vector.x, (int)vector.y] != null && board[(int)vector.x, (int)vector.y].parent != transform) return false;
            }
            catch (System.IndexOutOfRangeException)
            {
                return false;
            }*/
        }

        return true;
    }

    private void UpdateBoard() 
    {
        // Remove old children from grid
        for (int row = 0; row < HEIGHT; row++)
        {
            for (int column = 0; column < WIDTH; column++)
            {     
                if (board[column, row] != null && board[column, row].parent == transform) board[column, row] = null;
            }            
        }

        // Add new children to grid
        foreach (Transform child in transform) 
        {
            Vector2 vector = RoundVector2(child.position);
            board[(int)vector.x, (int)vector.y] = child;
        }        
    }
}

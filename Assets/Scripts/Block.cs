using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static GameBoard;

public class Block : MonoBehaviour
{
    private float lastFall = 0;
    public static bool isGameOver = false;
    private Vector2 startPos;
    private bool fingerDown;
    private int pixelDistToDetect = 100;

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
        if(fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }

        if (fingerDown)
        {
            //Up
            if(Input.touches[0].position.y >= startPos.y + pixelDistToDetect)
            {
                fingerDown = false;

                transform.Rotate(0, 0, -90);
       
                if (IsValidPosition()) UpdateBoard();
                else transform.Rotate(0, 0, 90);
            }

            //Down
            else if(Input.touches[0].position.y <= startPos.y - pixelDistToDetect)
            {
                fingerDown = false;
                PressDrop();
            }

            //Left
            else if(Input.touches[0].position.x <= startPos.x - pixelDistToDetect)
            {
                fingerDown = false;
                HorizontalMove(new Vector3(-1, 0, 0));
            }
    
            //Right
            else if(Input.touches[0].position.x >= startPos.x + pixelDistToDetect)
            {
                fingerDown = false;
                HorizontalMove(new Vector3(1, 0, 0)); 
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) HorizontalMove(new Vector3(-1, 0, 0));

        if (Input.GetKeyDown(KeyCode.RightArrow)) HorizontalMove(new Vector3(1, 0, 0));

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            PressDrop();
        }

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

    private void PressDrop()
    {
        while(true)
        {
            transform.position += new Vector3(0, -1, 0);

            if (IsValidPosition()) UpdateBoard();
            else 
            {
                transform.position += new Vector3(0, 1, 0);

                DeleteFullRows();
                FindObjectOfType<Spawner>().Spawn();
                
                break;
            }
        }

        enabled = false;
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
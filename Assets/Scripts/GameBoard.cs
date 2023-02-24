using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public static readonly int WIDTH = 11;
    public static readonly int HEIGHT = 23;
    public static Transform[,] board = new Transform[WIDTH, HEIGHT]; //column, row

    public static Vector2 RoundVector2(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }

    public static bool IsInside(Vector2 position)
    {
        return ((int)position.x >= 0 && (int)position.x < WIDTH && (int)position.y >= 0);
    }

    public static bool IsInBoard(Vector2 position)
    {
        return ((int)position.y < 20);
    }

    public static void DeleteRow(int row) 
    {
        for (int column = 0; column < WIDTH; column++) 
        {
            Destroy(board[column, row].gameObject);
            board[column, row] = null;
        }
    }

    public static void DecreaseRow(int row) 
    {
        for (int column = 0; column < WIDTH; column++) 
        {
            if (board[column, row] != null) 
            {   
                // Move one block towards bottom
                board[column, row-1] = board[column, row];
                board[column, row] = null;

                // Update block position
                board[column, row-1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void DecreaseUpperRow(int row) 
    {
        for (int i = row; i < HEIGHT; i++) DecreaseRow(i);
    }

    public static bool IsFullRow(int row) 
    {
        for (int column = 0; column < WIDTH; column++) 
        {
            if (board[column, row] == null) return false;
        }

        return true;
    }

    public static void DeleteFullRows() 
    {
        for (int row = 0; row < HEIGHT; row++) 
        {
            if (IsFullRow(row)) 
            {
                Data.consecutiveRow++;
                DeleteRow(row);
                DecreaseUpperRow(row+1);
                row--;
            }
        }

        Data.AddScore();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private const float TILE_SIZE = 1.9f;       //parameters of the tile size
    private const float TILE_OFFSET = 0.5f;

    private int selectionX = -1;                //Keeps track of current place on board
    private int selectionY = -1;

    public List<GameObject> chesspiecePrefabs;
    private List<GameObject> activeChesspiece;

    private Quaternion orientation = Quaternion.Euler(0, 360, 0);

    private void Start()
    {
        SpawnAllChessPieces();
    }

    private void Update()
    {
        UpdateSelection();
        DrawChessboard();
    }

    private void UpdateSelection()
    {
        if (!Camera.main)                       //to test this function
            return;

        RaycastHit hit;
       if(Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }

    private void SpawnChessPiece(int index, Vector3 position)
    {
        GameObject go = Instantiate(chesspiecePrefabs[index], position, orientation) as GameObject;
        go.transform.SetParent(transform);
        activeChesspiece.Add(go);
    }

    private void SpawnAllChessPieces()
    {
        activeChesspiece = new List<GameObject>();

        //Spawn White Pieces

        //King
        SpawnChessPiece(0, GetTileCenter(4, 0));

        //Queen
        SpawnChessPiece(1, GetTileCenter(3, 0));

        //Rooks
        SpawnChessPiece(2, GetTileCenter(0, 0));
        SpawnChessPiece(2, GetTileCenter(7, 0));

        //Bishops
        SpawnChessPiece(3, GetTileCenter(2, 0));
        SpawnChessPiece(3, GetTileCenter(5, 0));

        //Knights
        SpawnChessPiece(4, GetTileCenter(1, 0));
        SpawnChessPiece(4, GetTileCenter(6, 0));

        //Pawns
        for (int i = 0; i < 8; i++)
            SpawnChessPiece(5, GetTileCenter(i, 1));

        //Spawn Black Pieces

        //King
        SpawnChessPiece(6, GetTileCenter(3, 7));

        //Queen
        SpawnChessPiece(7, GetTileCenter(4, 7));

        //Rooks
        SpawnChessPiece(8, GetTileCenter(0, 7));
        SpawnChessPiece(8, GetTileCenter(7, 7));

        //Bishops
        SpawnChessPiece(9, GetTileCenter(2, 7));
        SpawnChessPiece(9, GetTileCenter(5, 7));

        //Knights
        SpawnChessPiece(10, GetTileCenter(1, 7));
        SpawnChessPiece(10, GetTileCenter(6, 7));

        //Pawns
        for (int i = 0; i < 8; i++)
            SpawnChessPiece(11, GetTileCenter(i, 6));
    }

    private Vector3 GetTileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;
        return origin;
    }

    private void DrawChessboard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heightLine = Vector3.forward * 8;

        for(int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightLine);
            }
        }

        //Draw the Selection
        if(selectionX >= 0 && selectionY >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));

            Debug.DrawLine(
                Vector3.forward * (selectionY + 1)+ Vector3.right * selectionX,
                Vector3.forward * selectionY + Vector3.right * (selectionX + 1));
        }
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private LayerMask _piecesLayer;

    public void Select(Tile tile)
    {
        var piece = GetPieceAt(tile.transform.position);
        piece?.Activate();
    }

    private Piece GetPieceAt(Vector3 position)
    {
        position.y = 2;

        Debug.DrawRay(position, Vector3.down * 2, Color.red, 2);

        if (Physics.Raycast(position, Vector3.down, out var hit, 2, _piecesLayer))
            return hit.collider.GetComponent<Piece>();

        return null;
    }
}

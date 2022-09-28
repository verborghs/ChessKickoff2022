using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private LayerMask _piecesLayer;

    [SerializeField]
    private LayerMask _tilesLayer;

    private Piece _selectedPiece;

    public void Select(Tile tile)
    {
        if (_selectedPiece)
        {
            if (_selectedPiece.Move(tile))
                _selectedPiece = null;
                
        }
        else
        {
            _selectedPiece = GetPieceAt(tile.transform.position);
            _selectedPiece?.Activate();
        }
    }

    public Piece GetPieceAt(Vector3 position)
    {
        position.y = 2;

        Debug.DrawRay(position, Vector3.down * 2, Color.red, 2);

        if (Physics.Raycast(position, Vector3.down, out var hit, 2, _piecesLayer))
            return hit.collider.GetComponent<Piece>();

        return null;
    }

    public Tile GetTileAt(Vector3 position)
    {
        position.y = 1;

        Debug.DrawRay(position, Vector3.down * 2, Color.green, 2);

        if (Physics.Raycast(position, Vector3.down, out var hit, 2, _tilesLayer))
            return hit.collider.GetComponent<Tile>();

        return null;
    }
}

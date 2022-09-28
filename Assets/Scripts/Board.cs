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
    private List<Tile> _validTiles = new List<Tile>();

    public void Select(Tile tile)
    {
        DeactivateValidTiles();

        if (_validTiles.Contains(tile))
        {
            _selectedPiece.Move(tile);

            ResetState();
        }
        else
        {
            TrySelectPiece(tile);

            ActivateValidTiles();
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

    private void ResetState()
    {
        _selectedPiece = null;
        _validTiles.Clear();
    }

    private void TrySelectPiece(Tile tile)
    {
        _selectedPiece = GetPieceAt(tile.transform.position);
        if (_selectedPiece != null)
            _validTiles = _selectedPiece.GetValidTiles();
    }

    private void ActivateValidTiles()
    {
        foreach (var tile in _validTiles)
            tile.Highlight();
    }

    private void DeactivateValidTiles()
    {
        foreach (var tile in _validTiles)
            tile.UnHighlight();
    }
}



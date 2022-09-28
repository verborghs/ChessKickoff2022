using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MovementHelper
{
    private readonly Board _board;
    private readonly Piece _piece;
    private List<Tile> _activatedTiles = new List<Tile>();


    public List<Tile> ActivatedTiles => _activatedTiles;

    public MovementHelper(Board board, Piece piece)
    {
        _board = board;
        _piece = piece;
    }

    public void Up() => Collect(_piece.transform.forward);

    public void Down() => Collect(-_piece.transform.forward);

    public void Left() => Collect(-_piece.transform.right);

    public void Right() => Collect(_piece.transform.right);

    public void Collect(Vector3 direction)
    {
        
        var tile = _board.GetTileAt(_piece.transform.position + direction);
        while (tile != null)
        {
            var piece = _board.GetPieceAt(tile.transform.position);
            if (piece == null || piece.Player != _piece.Player)
                _activatedTiles.Add(tile);

            if (piece != null)
                break;



            tile = _board.GetTileAt(tile.transform.position + direction);
        }
    }

    
}


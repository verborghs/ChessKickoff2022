using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Pawn : Piece
{
    private bool _hasMoved = false;

    private List<Tile> _activatedTiles = new List<Tile>();
    public override void Activate()
    {
        _activatedTiles.Clear();

        var tile1 = Board.GetTileAt(transform.position + transform.forward);
        if (tile1 != null)
        {
            var piece1 = Board.GetPieceAt(tile1.transform.position);
            if (piece1 == null)
            {
                _activatedTiles.Add(tile1);
                tile1.Highlight();

                if (!_hasMoved)
                {
                    var tile2 = Board.GetTileAt(transform.position + 2 * transform.forward);
                    if (tile2 != null)
                    {

                        var piece2 = Board.GetPieceAt(tile2.transform.position);
                        if (piece2 == null)
                        {
                            _activatedTiles.Add(tile2);
                            tile2.Highlight();
                        }
                    }
                }
            }
        }

        var tile3 = Board.GetTileAt(transform.position + transform.forward + transform.right);
        if (tile3 != null)
        {
            var piece3 = Board.GetPieceAt(tile3.transform.position);
            if (piece3 != null)
            {
                _activatedTiles.Add(tile3);
                tile3.Highlight();
            }
        }

        var tile4 = Board.GetTileAt(transform.position + transform.forward - transform.right);
        if (tile4 != null)
        {
            var piece4 = Board.GetPieceAt(tile4.transform.position);
            if (piece4 != null)
            {
                _activatedTiles.Add(tile4);
                tile4.Highlight();
            }
                
        }
    }

    public override bool Move(Tile tile)
    {
        if (!_activatedTiles.Contains(tile))
            return false;

        transform.position = tile.transform.position;

        foreach (var activatedTile in _activatedTiles)
            activatedTile.UnHighlight();

        return true;
    }
}


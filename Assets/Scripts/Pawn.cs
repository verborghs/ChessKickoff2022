using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Pawn : Piece
{
    private bool _hasMoved = false;

    public override List<Tile> GetValidTiles()
    {
        List<Tile> activatedTiles = new List<Tile>();
        var tile1 = Board.GetTileAt(transform.position + transform.forward);
        if (tile1 != null)
        {
            var piece1 = Board.GetPieceAt(tile1.transform.position);
            if (piece1 == null)
            {
                activatedTiles.Add(tile1);

                if (!_hasMoved)
                {
                    var tile2 = Board.GetTileAt(transform.position + 2 * transform.forward);
                    if (tile2 != null)
                    {
                        var piece2 = Board.GetPieceAt(tile2.transform.position);
                        if (piece2 == null)
                            activatedTiles.Add(tile2);
                    }
                }
            }

            var tile3 = Board.GetTileAt(transform.position + transform.forward + transform.right);
            if (tile3 != null)
            {
                var piece3 = Board.GetPieceAt(tile3.transform.position);
                if (piece3 != null)
                    activatedTiles.Add(tile3);
            }
            
            var tile4 = Board.GetTileAt(transform.position + transform.forward - transform.right);
            if (tile4 != null)
            {
                var piece4 = Board.GetPieceAt(tile4.transform.position);
                if (piece4 != null)
                    activatedTiles.Add(tile4);
            }

            
        }

        return activatedTiles;
    }

}


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
        MovementHelper.TileValidator empty = (b, p, t) => Board.GetPieceAt(t.transform.position) == null;

        return new MovementHelper(Board, this)
            .Up(1, empty)
            .UpLeft(1, HasEnemy)
            .UpRight(1, HasEnemy)
            .Up(2, (b,p,t) => !_hasMoved, empty)
            .ActivatedTiles;       
    }

    public bool HasEnemy(Board b, Piece p, Tile t)
    {
        var piece = Board.GetPieceAt(t.transform.position);
        return piece != null && piece.Player != p.Player;
    }
}


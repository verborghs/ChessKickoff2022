using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bishop : Piece
{
    public override List<Tile> GetValidTiles()
    {
        return new MovementHelper(Board, this)
            .UpLeft()
            .UpRight()
            .DownLeft()
            .DownRight()
            .ActivatedTiles;
    }
}


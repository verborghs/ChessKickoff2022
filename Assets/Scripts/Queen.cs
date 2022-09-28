using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Queen : Piece
{
    public override List<Tile> GetValidTiles()
    {
        return new MovementHelper(Board, this)
            .Up()
            .Down()
            .Left()
            .Right()
            .UpLeft()
            .UpRight()
            .DownLeft()
            .DownRight()
            .ActivatedTiles;
    }
}


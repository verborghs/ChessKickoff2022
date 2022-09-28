using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class King : Piece
{
    public override List<Tile> GetValidTiles()
    {
        return new MovementHelper(Board, this)
            .Up(1)
            .Down(1)
            .Left(1)
            .Right(1)
            .UpLeft(1)
            .UpRight(1)
            .DownLeft(1)
            .DownRight(1)
            .ActivatedTiles;
    }
}

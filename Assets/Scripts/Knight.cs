using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Knight : Piece
{
    public override List<Tile> GetValidTiles()
    {
        return new MovementHelper(Board, this)
            .Collect(transform.forward * 2 + transform.right, 1)
            .Collect(transform.forward * 2 - transform.right, 1)
            .Collect(-transform.forward * 2 + transform.right, 1)
            .Collect(-transform.forward * 2 - transform.right, 1)
            .Collect(transform.forward + transform.right * 2, 1)
            .Collect(transform.forward - transform.right * 2, 1)
            .Collect(-transform.forward + transform.right * 2, 1)
            .Collect(-transform.forward - transform.right * 2, 1)
            .ActivatedTiles;
    }
}

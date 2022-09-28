using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rook : Piece
{
    public override List<Tile> GetValidTiles()
    {
        List<Tile> activatedTiles = new List<Tile>();
        Up(activatedTiles);
        Down(activatedTiles);
        Left(activatedTiles);
        Right(activatedTiles);


        return activatedTiles;
    }

    private void Up(List<Tile> activatedTiles)
    {
        var direction = transform.forward;
        var tile = Board.GetTileAt(transform.position + direction);
        while(tile != null)
        {
            var piece = Board.GetPieceAt(tile.transform.position);
            if (piece == null || piece.Player != Player)
                activatedTiles.Add(tile);

            if (piece != null)
                break;

            

            tile = Board.GetTileAt(tile.transform.position + direction);
        }
    }

    private void Down(List<Tile> activatedTiles)
    {
        var direction = -transform.forward;
        var tile = Board.GetTileAt(transform.position + direction);
        while (tile != null)
        {
            activatedTiles.Add(tile);

            var piece = Board.GetPieceAt(tile.transform.position);
            if (piece != null)
                break;

            tile = Board.GetTileAt(tile.transform.position + direction);
        }
    }

    private void Left(List<Tile> activatedTiles)
    {
        var direction = -transform.right;
        var tile = Board.GetTileAt(transform.position + direction);
        while (tile != null)
        {
            activatedTiles.Add(tile);

            var piece = Board.GetPieceAt(tile.transform.position);
            if (piece != null)
                break;

            tile = Board.GetTileAt(tile.transform.position + direction);
        }
    }

    private void Right(List<Tile> activatedTiles)
    {
        var direction = transform.right;
        var tile = Board.GetTileAt(transform.position + direction);
        while (tile != null)
        {
            activatedTiles.Add(tile);

            var piece = Board.GetPieceAt(tile.transform.position);
            if (piece != null)
                break;

            tile = Board.GetTileAt(tile.transform.position + direction);
        }
    }
}


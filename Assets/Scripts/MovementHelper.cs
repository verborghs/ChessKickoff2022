using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MovementHelper
{
    public delegate bool TileValidator(Board board, Piece startPiece, Tile targetTile);

    private readonly Board _board;
    private readonly Piece _piece;
    private List<Tile> _activatedTiles = new List<Tile>();



    public List<Tile> ActivatedTiles => _activatedTiles;

    public MovementHelper(Board board, Piece piece)
    {
        _board = board;
        _piece = piece;
    }

    public MovementHelper Up(int maxSteps = int.MaxValue, params TileValidator[] validators) => Collect(_piece.transform.forward, maxSteps, validators);

    public MovementHelper Down(int maxSteps = int.MaxValue, params TileValidator[] validators) => Collect(-_piece.transform.forward, maxSteps, validators);

    public MovementHelper Left(int maxSteps = int.MaxValue, params TileValidator[] validators) => Collect(-_piece.transform.right, maxSteps, validators);

    public MovementHelper Right(int maxSteps = int.MaxValue, params TileValidator[] validators) => Collect(_piece.transform.right, maxSteps, validators);

    public MovementHelper UpLeft(int maxSteps = int.MaxValue, params TileValidator[] validators) => Collect(_piece.transform.forward - _piece.transform.right, maxSteps, validators);

    public MovementHelper UpRight(int maxSteps = int.MaxValue, params TileValidator[] validators) => Collect(_piece.transform.forward + _piece.transform.right, maxSteps, validators);

    public MovementHelper DownLeft(int maxSteps = int.MaxValue, params TileValidator[] validators) => Collect(-_piece.transform.forward  - _piece.transform.right, maxSteps, validators);

    public MovementHelper DownRight(int maxSteps = int.MaxValue, params TileValidator[] validators) => Collect(-_piece.transform.forward + _piece.transform.right, maxSteps, validators);

    public MovementHelper Collect(Vector3 direction, int maxSteps = int.MaxValue, params TileValidator[] validators)
    {
        
        var tile = _board.GetTileAt(_piece.transform.position + direction);
        var step = 1;
        while (tile != null && step <= maxSteps && Validate(tile, validators))
        {


            var piece = _board.GetPieceAt(tile.transform.position);
            if (piece == null || piece.Player != _piece.Player)
                _activatedTiles.Add(tile);

            if (piece != null)
                break;



            tile = _board.GetTileAt(tile.transform.position + direction);
            step++;
        }

        return this;
    }

    private bool Validate(Tile tile, TileValidator[] validators)
    {
        foreach (var validator in validators)
            if (!validator(_board, _piece, tile))
                return false;

        return true;
    }
}


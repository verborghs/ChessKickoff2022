using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    protected Board Board;

    private void OnEnable()
        => Board = FindObjectOfType<Board>();

    public abstract List<Tile> GetValidTiles();

    public void Move(Tile tile)
        => transform.position = tile.transform.position;
    

    public void Take()
        => gameObject.SetActive(false);
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    protected Board Board;

    public Player Player => _player;

    private void OnEnable()
        => Board = FindObjectOfType<Board>();

    public abstract List<Tile> GetValidTiles();

    public void Move(Tile tile)
        => transform.position = tile.transform.position;
    

    public void Take()
        => gameObject.SetActive(false);
    
}

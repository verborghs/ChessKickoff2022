using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    protected Board Board;

    private void OnEnable()
        => Board = FindObjectOfType<Board>();

    public abstract void Activate();

    public abstract bool Move(Tile tile);

    public void Take()
    {
        gameObject.SetActive(false);
    }
}

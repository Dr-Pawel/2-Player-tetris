using UnityEngine;

public class TetrominoShapes
{
    public static readonly Vector2Int[] I = {
        new Vector2Int(-1, 0), new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(2, 0)
    };

    public static readonly Vector2Int[] O = {
        new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(0, -1), new Vector2Int(1, -1)
    };

    public static readonly Vector2Int[] T = {
        new Vector2Int(-1, 0), new Vector2Int(0, 0), new Vector2Int(1, 0), new Vector2Int(0, 1)
    };

    public static readonly Vector2Int[] L = {
        new Vector2Int(0, -1), new Vector2Int(0, 0), new Vector2Int(0, 1), new Vector2Int(1, 1)
    };
}

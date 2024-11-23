using UnityEngine;

public static class DirectionUtils
{
    private static readonly Vector2[] Directions = new Vector2[]
    {
        new Vector2(1, 0),    // Droite
        new Vector2(1, 1),    // Top-droite
        new Vector2(0, 1),    // Top
        new Vector2(-1, 1),   // Top-gauche
        new Vector2(-1, 0),   // Gauche
        new Vector2(-1, -1),  // Down-gauche
        new Vector2(0, -1),   // Down
        new Vector2(1, -1)    // Down-droite
    };

    public static Vector2 ConvertTo8Direction(this Vector2 input)
    {
        if (input == Vector2.zero)
            return Vector2.zero;

        //! ty to chatGPT :/
        Vector2 normalized = input.normalized;
        float angle = Mathf.Atan2(normalized.y, normalized.x);
        // Conversion en angle positif entre 0 et 2*PI
        angle = (angle + Mathf.PI * 2) % (Mathf.PI * 2);
        // Convertir l'angle en une des 8 directions
        int index = Mathf.RoundToInt(angle / (Mathf.PI / 4)) % 8;

        return Directions[index];
    }
}


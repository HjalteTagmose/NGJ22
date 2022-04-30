using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public static class Extensions 
{
    public static Color Blend(this Color color, Color backColor, float amount)
    {
        float r = color.r * amount + backColor.r * (1f - amount);
        float g = color.g * amount + backColor.g * (1f - amount);
        float b = color.b * amount + backColor.b * (1f - amount);
        return new Color(r, g, b);
    }

    public static void Shuffle<T>(this Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}

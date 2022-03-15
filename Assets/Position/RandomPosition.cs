using UnityEngine;

public class RandomPosition 
{
    private readonly Vector2 _min;
    private readonly Vector2 _max;

    public RandomPosition(Vector3 min, Vector3 max)
    {
        _min = min;
        _max = max;
    }

    public Vector2 Get()
    {
        var randomX = Random.Range(_min.x, _max.x);
        var randomY = Random.Range(_min.y, _max.y);

        return new Vector2(randomX, randomY);
    }
}
using UnityEngine;

public static class ScreenUtils
{
    private static float _sceneWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
    private static float _sceneHeight = Camera.main.orthographicSize * 2;

    private static float _sceneRightEdge = _sceneWidth / 2;
    private static float _sceneLeftEdge = _sceneRightEdge * -1;
    private static float _sceneTopEdge = _sceneHeight / 2;
    private static float _sceneBottomEdge = _sceneTopEdge * -1;

    public static float SceneWidth => _sceneWidth;
    public static float SceneHeight => _sceneHeight;
    public static Vector2 GetRandomBorderPointPosition(float buffer)
    {
        int border = Random.Range(0, 4);
        switch (border)
        {
            case 0: return new Vector2(Random.Range(_sceneLeftEdge, _sceneRightEdge), _sceneTopEdge + buffer);
            case 1: return new Vector2(Random.Range(_sceneLeftEdge, _sceneRightEdge), _sceneBottomEdge - buffer);
            case 2: return new Vector2(_sceneLeftEdge - buffer, Random.Range(_sceneBottomEdge, _sceneTopEdge));
            case 3: return new Vector2(_sceneRightEdge + buffer, Random.Range(_sceneBottomEdge, _sceneTopEdge));
            default: return new Vector2(Random.Range(_sceneLeftEdge, _sceneRightEdge), _sceneTopEdge + buffer);
        }
    }

    public static Vector2 GetRandomHorizontalBorderPointPosition(float bufferCoef)
    {
        int border = Random.Range(0, 2);
        float botttomEdge = (float)(_sceneBottomEdge + _sceneHeight * bufferCoef);
        float TopEdge = (float)(_sceneTopEdge - _sceneHeight * bufferCoef);

        switch (border)
        {
            case 0: return new Vector2(_sceneLeftEdge, Random.Range(botttomEdge, TopEdge));
            case 1: return new Vector2(_sceneRightEdge, Random.Range(botttomEdge, TopEdge));
            default: return new Vector2(_sceneLeftEdge, Random.Range(botttomEdge, TopEdge));
        }
    }

    public static Vector2 GetRandomBorderPointPosition()
    {
         return GetRandomBorderPointPosition(0);
    }

    public static void KeepWithinTheScreen(Transform transform)
    {
        float sceneWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        float sceneHeight = Camera.main.orthographicSize * 2;

        float sceneRightEdge = sceneWidth / 2;
        float sceneLeftEdge = sceneRightEdge * -1;
        float sceneTopEdge = sceneHeight / 2;
        float sceneBottomEdge = sceneTopEdge * -1;

        if (transform.position.x > sceneRightEdge)
        {
            transform.position = new Vector2(sceneLeftEdge, transform.position.y);
        }
        if (transform.position.x < sceneLeftEdge)
        {
            transform.position = new Vector2(sceneRightEdge, transform.position.y);
        }
        if (transform.position.y > sceneTopEdge)
        {
            transform.position = new Vector2(transform.position.x, sceneBottomEdge);
        }
        if (transform.position.y < sceneBottomEdge)
        {
            transform.position = new Vector2(transform.position.x, sceneTopEdge);
        }
    }

    public static bool IsWithinScreen(Transform transform, float buffer)
    {
        if (transform.position.x > _sceneRightEdge + buffer) return false;
        if (transform.position.x < _sceneLeftEdge - buffer) return false;
        if (transform.position.y > _sceneTopEdge + buffer) return false;
        if (transform.position.y < _sceneBottomEdge - buffer) return false;
        return true;
    }

    public static bool IsWithinScreen(Transform transform)
    {
        return IsWithinScreen(transform, 0);
    }
}

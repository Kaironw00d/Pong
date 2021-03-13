using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundParalax : MonoBehaviour
{
    private enum Anchor
    {
        LeftTop,
        LeftBottom,
        RightBottom,
        RightTop
    }
    
    [SerializeField] private Camera targetCamera;
    [SerializeField] private float smoothness = 100f;
    
    private SpriteRenderer _spriteRenderer;
    private Vector3 _leftTop;
    private Vector3 _leftBottom;
    private Vector3 _rightBottom;
    private Vector3 _rightTop;

    private Anchor _currentTargetAnchor = Anchor.LeftTop;

    private Vector3 _velocity = Vector3.zero;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        var orthographicSize = targetCamera.orthographicSize;
        var cameraX = targetCamera.aspect * orthographicSize;
        var cameraY = orthographicSize;
        var bounds = _spriteRenderer.bounds;
        var backgroundX = bounds.extents.x;
        var backgroundY = bounds.extents.y;

        _leftTop = new Vector2(-cameraX, cameraY) - new Vector2(-backgroundX, backgroundY);
        _leftBottom = new Vector2(-cameraX, -cameraY) - new Vector2(-backgroundX, -backgroundY);
        _rightBottom = new Vector2(cameraX, -cameraY) - new Vector2(backgroundX, -backgroundY);
        _rightTop = new Vector2(cameraX, cameraY) - new Vector2(backgroundX, backgroundY);
    }

    private void LateUpdate()
    {
        switch (_currentTargetAnchor)
        {
            case Anchor.LeftTop:
                MoveToTarget(_leftTop);
                if (CloseToAnchor(_leftTop))
                    _currentTargetAnchor = GetNewAnchor();
                break;
            case Anchor.LeftBottom:
                MoveToTarget(_leftBottom);
                if (CloseToAnchor(_leftBottom))
                    _currentTargetAnchor = GetNewAnchor();
                break;
            case Anchor.RightBottom:
                MoveToTarget(_rightBottom);
                if (CloseToAnchor(_rightBottom))
                    _currentTargetAnchor = GetNewAnchor();
                break;
            case Anchor.RightTop:
                MoveToTarget(_rightTop);
                if (CloseToAnchor(_rightTop))
                    _currentTargetAnchor = GetNewAnchor();
                break;
        }
    }

    private static Anchor GetNewAnchor() => (Anchor)Random.Range(0, 4);

    private void MoveToTarget(Vector3 targetPos) => transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, smoothness * Time.deltaTime);

    private bool CloseToAnchor(Vector3 targetPos) => (targetPos - transform.position).sqrMagnitude < 1;
}

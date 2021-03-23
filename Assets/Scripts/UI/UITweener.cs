using UnityEngine;

#region Animation Types
public enum AnimationType
{
    MoveX,
    MoveY,
    Move,
    MoveLocalX,
    MoveLocalY,
    MoveLocal,
    RotateX,
    RotateY,
    RotateZ,
    Rotate,
    RotateLocal,
    ScaleX,
    ScaleY,
    ScaleZ,
    Scale,
    Alpha,
    Color
}
#endregion

public class UITweener : MonoBehaviour
{
    public GameObject objectToAnimate;
    public GameObject objectToDisable;
    public bool showOnEnable;
    public bool loop;
    public bool pingPong;
    public bool useUnscaledTime;

    public float duration;
    public float delay;
    public AnimationType animationType;
    public LeanTweenType easeType;
    public bool startOffset;
    public float floatFrom;
    public float floatTo;
    public Vector3 vectorFrom;
    public Vector3 vectorTo;
    public Color colorFrom;
    public Color colorTo;

    private LTDescr _tweenObject;
    private RectTransform _objRectTransform;
    private CanvasGroup _objCanvasGroup;
    private Color _objColor;

    private void Awake()
    {
        if (objectToAnimate == null)
            objectToAnimate = gameObject;
        if (objectToDisable == null)
            objectToDisable = gameObject;
        switch (animationType)
        {
            case AnimationType.Alpha:
                _objCanvasGroup = objectToAnimate.GetComponent<CanvasGroup>();
                break;
            case AnimationType.Color:
                _objColor = objectToAnimate.GetComponent<Material>().color;
                break;
            default:
                _objRectTransform = objectToAnimate.GetComponent<RectTransform>();
                break;
        }
    }

    private void OnEnable()
    {
        if (!showOnEnable) return;
        Show();
    }

    public void Show()
    {
        HandleTween();
    }

    private void HandleTween()
    {
        switch(animationType)
        {
            case AnimationType.MoveX:
                MoveX();
                break;
            case AnimationType.MoveY:
                MoveY();
                break;
            case AnimationType.Move:
                Move();
                break;
            case AnimationType.MoveLocalX:
                MoveLocalX();
                break;
            case AnimationType.MoveLocalY:
                MoveLocalY();
                break;
            case AnimationType.MoveLocal:
                MoveLocal();
                break;
            case AnimationType.RotateX:
                RotateX();
                break;
            case AnimationType.RotateY:
                RotateY();
                break;
            case AnimationType.RotateZ:
                RotateZ();
                break;
            case AnimationType.Rotate:
                Rotate();
                break;
            case AnimationType.RotateLocal:
                RotateLocal();
                break;
            case AnimationType.ScaleX:
                ScaleX();
                break;
            case AnimationType.ScaleY:
                ScaleY();
                break;
            case AnimationType.ScaleZ:
                ScaleZ();
                break;
            case AnimationType.Scale:
                Scale();
                break;
            case AnimationType.Alpha:
                Fade();
                break;
            case AnimationType.Color:
                Color();
                break;
        }
        
        _tweenObject.setDelay(delay);
        _tweenObject.setEase(easeType);
        _tweenObject.setIgnoreTimeScale(useUnscaledTime);
        
        if(loop)
            _tweenObject.setLoopCount(int.MaxValue);
        if (pingPong)
            _tweenObject.setLoopPingPong();
    }

    private void SwapValues()
    {
        switch (animationType)
        {
            case AnimationType.Color:
            {
                Color temp = colorFrom;
                colorFrom = colorTo;
                colorTo = temp;
                break;
            }
            case AnimationType.Move:
            case AnimationType.MoveLocal:
            case AnimationType.Rotate:
            case AnimationType.RotateLocal:
            case AnimationType.Scale:
            {
                Vector3 temp = vectorFrom;
                vectorFrom = vectorTo;
                vectorTo = temp;
                break;
            }
            default:
            {
                float temp = floatFrom;
                floatFrom = floatTo;
                floatTo = temp;
                break;
            }
        }
    }

    public void Hide()
    {
        SwapValues();

        HandleTween();

        _tweenObject.setOnComplete(() =>
        {
            SwapValues();
            objectToDisable.SetActive(false);
        });
    }

    #region Animating
    private void MoveX()
    {
        if(startOffset)
        {
            _objRectTransform.anchoredPosition = new Vector2(floatFrom, _objRectTransform.anchoredPosition.y);
        }
        _tweenObject = LeanTween.moveX(_objRectTransform, floatTo, duration);
    }

    private void MoveY()
    {
        if(startOffset)
        {
            _objRectTransform.anchoredPosition = new Vector2(_objRectTransform.anchoredPosition.x, floatFrom);
        }
        _tweenObject = LeanTween.moveY(_objRectTransform, floatTo, duration);
    }
    
    private void Move()
    {
        if(startOffset)
        {
            _objRectTransform.anchoredPosition = new Vector2(vectorFrom.x, vectorFrom.y);
        }
        _tweenObject = LeanTween.move(_objRectTransform, vectorTo, duration);
    }

    private void MoveLocalX()
    {
        if(startOffset)
        {
            var localPosition = _objRectTransform.localPosition;
            localPosition = new Vector3(floatFrom, localPosition.y, localPosition.z);
            _objRectTransform.localPosition = localPosition;
        }
        _tweenObject = LeanTween.moveLocalX(objectToAnimate, floatTo, duration);
    }

    private void MoveLocalY()
    {
        if(startOffset)
        {
            var localPosition = _objRectTransform.localPosition;
            localPosition = new Vector3(localPosition.x, floatFrom, localPosition.z);
            _objRectTransform.localPosition = localPosition;
        }
        _tweenObject = LeanTween.moveLocalY(objectToAnimate, floatTo, duration);
    }

    private void MoveLocal()
    {
        if(startOffset)
        {
            _objRectTransform.localPosition = vectorFrom;
        }
        _tweenObject = LeanTween.moveLocal(objectToAnimate, vectorTo, duration);
    }

    private void RotateX()
    {
        if(startOffset)
        {
            var rotation = _objRectTransform.rotation;
            rotation = Quaternion.Euler(floatFrom, rotation.y, rotation.z);
            _objRectTransform.rotation = rotation;
        }
        _tweenObject = LeanTween.rotateX(objectToAnimate, floatTo, duration);
    }

    private void RotateY()
    {
        if(startOffset)
        {
            var rotation = _objRectTransform.rotation;
            rotation = Quaternion.Euler(rotation.x, floatFrom, rotation.z);
            _objRectTransform.rotation = rotation;
        }
        _tweenObject = LeanTween.rotateY(objectToAnimate, floatTo, duration);
    }

    private void RotateZ()
    {
        if(startOffset)
        {
            var rotation = _objRectTransform.rotation;
            rotation = Quaternion.Euler(rotation.x, rotation.y, floatFrom);
            _objRectTransform.rotation = rotation;
        }
        _tweenObject = LeanTween.rotateZ(objectToAnimate, floatTo, duration);
    }

    private void Rotate()
    {
        if(startOffset)
        {
            _objRectTransform.rotation = Quaternion.Euler(vectorFrom);
        }
        _tweenObject = LeanTween.rotate(objectToAnimate, vectorTo, duration);
    }

    private void RotateLocal()
    {
        if(startOffset)
        {
            _objRectTransform.localRotation = Quaternion.Euler(vectorFrom);
        }
        _tweenObject = LeanTween.rotateLocal(objectToAnimate, vectorTo, duration);
    }

    private void ScaleX()
    {
        if(startOffset)
        {
            var localScale = _objRectTransform.localScale;
            localScale = new Vector3(floatFrom, localScale.y, localScale.z);
            _objRectTransform.localScale = localScale;
        }
        _tweenObject = LeanTween.scaleX(objectToAnimate, floatTo, duration);
    }

    private void ScaleY()
    {
        if(startOffset)
        {
            var localScale = _objRectTransform.localScale;
            localScale = new Vector3(localScale.x, floatFrom, localScale.z);
            _objRectTransform.localScale = localScale;
        }
        _tweenObject = LeanTween.scaleY(objectToAnimate, floatTo, duration);
    }

    private void ScaleZ()
    {
        if(startOffset)
        {
            var localScale = _objRectTransform.localScale;
            localScale = new Vector3(localScale.x, localScale.y, floatFrom);
            _objRectTransform.localScale = localScale;
        }
        _tweenObject = LeanTween.scaleZ(objectToAnimate, floatTo, duration);
    }


    private void Scale()
    {
        if(startOffset)
        {
            _objRectTransform.localScale = vectorFrom;
        }
        _tweenObject = LeanTween.scale(objectToAnimate, vectorTo, duration);
    }

    private void Fade()
    {
        if(startOffset)
        {
            _objCanvasGroup.alpha = floatFrom;
        }
        _tweenObject = LeanTween.alphaCanvas(_objCanvasGroup, floatTo, duration);
    }

    private void Color()
    {
        if(startOffset)
        {
            _objColor = colorFrom;
        }
        _tweenObject = LeanTween.color(objectToAnimate, colorTo, duration);
    }
    #endregion
}
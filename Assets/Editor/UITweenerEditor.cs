using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(UITweener))]
public class UITweenerEditor : Editor
{
    private UITweener _tweener;

    private void OnEnable() => _tweener = (UITweener)target;
    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical("box");

        EditorGUILayout.BeginVertical("box");
        //EditorGUILayout.LabelField("References", EditorStyles.boldLabel);
        _tweener.objectToAnimate = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Object To Animate", "GameObject that will be animated.\nBy default will be used this GameObject."), _tweener.objectToAnimate, typeof(GameObject), true);
        _tweener.objectToDisable = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Object To Disable", "GameObject that will be disabled after calling Hide().\nBy default will be used this GameObject."), _tweener.objectToDisable, typeof(GameObject), true);
        EditorGUILayout.EndVertical();

        EditorGUILayout.Separator();

        EditorGUILayout.BeginVertical("box");
        //EditorGUILayout.LabelField("Common", EditorStyles.boldLabel);
        _tweener.duration = EditorGUILayout.Slider("Duration", _tweener.duration, 0f, 2f);
        _tweener.delay = EditorGUILayout.Slider("Delay", _tweener.delay, 0f, 2f);
        _tweener.easeType = (LeanTweenType)EditorGUILayout.EnumPopup(new GUIContent("Ease Type", "Applies different easing behavior."), _tweener.easeType);
        _tweener.animationType = (AnimationType)EditorGUILayout.EnumPopup(new GUIContent("Animation Type", "Applies different animation types"), _tweener.animationType);
        _tweener.startOffset = EditorGUILayout.Toggle("Start Offset", _tweener.startOffset);
        DrawPropriateFields();
        EditorGUILayout.EndVertical();

        EditorGUILayout.Separator();

        EditorGUILayout.BeginVertical("box");
        _tweener.showOnEnable = EditorGUILayout.Toggle("Animate On Enable", _tweener.showOnEnable);
        _tweener.loop = EditorGUILayout.Toggle("Loop", _tweener.loop);
        _tweener.pingPong = EditorGUILayout.Toggle("PingPong", _tweener.pingPong);
        _tweener.useUnscaledTime = EditorGUILayout.Toggle("Use Unscaled Time", _tweener.useUnscaledTime);
        EditorGUILayout.EndVertical();

        EditorGUILayout.EndVertical();
        
        if(GUI.changed)
            SetDirty(_tweener.gameObject);
    }
    public void SetDirty(GameObject obj)
    {
        EditorUtility.SetDirty(obj);
        EditorSceneManager.MarkSceneDirty(obj.scene);
    }
    private void DrawFloatFields()
    {
        if(_tweener.startOffset)
            _tweener.floatFrom = EditorGUILayout.FloatField("Start", _tweener.floatFrom);
        _tweener.floatTo = EditorGUILayout.FloatField("Destination", _tweener.floatTo);
    }
    private void DrawVectorFields()
    {
        if(_tweener.startOffset)
            _tweener.vectorFrom = EditorGUILayout.Vector3Field("Start", _tweener.vectorFrom);
        _tweener.vectorTo = EditorGUILayout.Vector3Field("Destination", _tweener.vectorTo);
    }
    private void DrawColorFields()
    {
        if(_tweener.startOffset)
            _tweener.colorFrom = EditorGUILayout.ColorField("Start", _tweener.colorFrom);
        _tweener.colorTo = EditorGUILayout.ColorField("Destination", _tweener.colorTo);
    }
    private void DrawPropriateFields()
    {
        if(_tweener.animationType == AnimationType.Color)
        {
            DrawColorFields();
        }
        else if(_tweener.animationType == AnimationType.Move
            || _tweener.animationType == AnimationType.MoveLocal
            || _tweener.animationType == AnimationType.Rotate
            ||_tweener.animationType == AnimationType.RotateLocal
            ||_tweener.animationType == AnimationType.Scale)
        {
            DrawVectorFields();
        }
        else
        {
            DrawFloatFields();
        }
    }
}

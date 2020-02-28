using UnityEngine;
using UnityEditor;
using System;

public class AiryUIAnchorsEditorWindow : EditorWindow
{
    private static EditorWindow window;
    private GUIStyle buttonContentStyle;

    [MenuItem("Airy UI/Anchors Window &%r", priority = 1)]
    private static void ShowWindow()
    {
        window = GetWindow<AiryUIAnchorsEditorWindow>("Anchors Editor");
        window.Show();
        window.maxSize = new Vector2(280, 590);
        window.minSize = new Vector2(280, 590);
    }

    private void OnGUI()
    {
        buttonContentStyle = new GUIStyle(GUI.skin.button);
        buttonContentStyle.normal.textColor = Color.white;
        buttonContentStyle.fontSize = 17;
        buttonContentStyle.fixedHeight = 50;

        GUI.color = Color.gray;

        WindowTitle_LABEL();

        GUI.color = Color.white;
        GUI.backgroundColor = Color.black;

        SetAnchorsToFitRect();

        GUI.color = Color.white;
        GUI.backgroundColor = Color.grey;

        SetAnchorsCenterOfRect();
        SetAnchorsTopRight();
        SetAnchorsTopLeft();
        SetAnchorsBottomRight();
        SetAnchorsBottomLeft();

        GUI.color = Color.white;
        GUI.backgroundColor = Color.blue;

        SetRectToAnchorSelectedGameObject();

        RateBox();
    }

    private void WindowTitle_LABEL()
    {
        GUILayout.Space(10);

        var titleLabelStyle = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.UpperCenter, fontSize = 30, fontStyle = FontStyle.Bold, fixedHeight = 50 };

        EditorGUILayout.LabelField("Anchors Editor", titleLabelStyle);
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();

        GUILayout.Space(30);
    }

    private void SetAnchorsToFitRect()
    {
        if (GUILayout.Button("Align Anchors With Rect\nCtrl+Shift+Q", buttonContentStyle))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    Undo.RecordObject(rectTransform, "Set Anchors");
                    AiryUIAnchors.SetAnchorsToRect(rectTransform);
                }
            }
        }

        GUILayout.Label("Note: You may need to click twice to fit the anchors if the pivot is not centered", new GUIStyle() { alignment = TextAnchor.MiddleCenter, wordWrap = true });

        GUILayout.Space(20);
    }

    [MenuItem("Airy UI/Anchors/Set Anchors To Fit Rect %#q", priority = 2)]
    public static void SetAnchorsToFitRect_Shortcut()
    {
        GameObject[] selectedGameObjects = Selection.gameObjects;

        foreach (var g in selectedGameObjects)
        {
            RectTransform rectTransform = g.GetComponent<RectTransform>();

            if (rectTransform != null)
            {
                Undo.RecordObject(rectTransform, "Set Anchors");
                AiryUIAnchors.SetAnchorsToRect(rectTransform);
            }
        }
    }

    private void SetAnchorsCenterOfRect()
    {
        if (GUILayout.Button("Set Anchors To Center Of Rect", buttonContentStyle))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    Undo.RecordObject(rectTransform, "Set Anchors");
                    AiryUIAnchors.SetAnchorsCenterOfRect(rectTransform);
                }
            }
        }
    }

    private void SetAnchorsTopRight()
    {
        if (GUILayout.Button("Set Anchors Top Right", buttonContentStyle))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    Undo.RecordObject(rectTransform, "Set Anchors");
                    AiryUIAnchors.SetAnchorsTopRight(rectTransform);
                }
            }
        }
    }

    private void SetAnchorsTopLeft()
    {
        if (GUILayout.Button("Set Anchors Top Left", buttonContentStyle))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    Undo.RecordObject(rectTransform, "Set Anchors");
                    AiryUIAnchors.SetAnchorsTopLeft(rectTransform);
                }
            }
        }
    }

    private void SetAnchorsBottomRight()
    {
        if (GUILayout.Button("Set Anchors Bottom Right", buttonContentStyle))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    Undo.RecordObject(rectTransform, "Set Anchors");
                    AiryUIAnchors.SetAnchorsBottomRight(rectTransform);
                }
            }
        }
    }

    private void SetAnchorsBottomLeft()
    {
        if (GUILayout.Button("Set Anchors Bottom Left", buttonContentStyle))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    Undo.RecordObject(rectTransform, "Set Anchors");
                    AiryUIAnchors.SetAnchorsBottomLeft(rectTransform);
                }
            }
        }

        GUILayout.Space(20);
    }

    private void SetRectToAnchorSelectedGameObject()
    {
        if (GUILayout.Button("Align Rect To Anchors\nCtrl+Shift+W", buttonContentStyle))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    Undo.RecordObject(rectTransform, "Set Anchors");
                    AiryUIAnchors.SetRectToAnchor(rectTransform);
                }
            }
        }

        GUILayout.Space(5);
    }

    [MenuItem("Airy UI/Anchors/Align Selected To Anchors %#w", priority = 2)]
    public static void SetRectToAnchorSelectedGameObject_Shortcut()
    {
        GameObject[] selectedGameObjects = Selection.gameObjects;

        foreach (var g in selectedGameObjects)
        {
            RectTransform rectTransform = g.GetComponent<RectTransform>();

            if (rectTransform != null)
            {
                Undo.RecordObject(rectTransform, "Set Anchors");
                AiryUIAnchors.SetRectToAnchor(rectTransform);
            }
        }
    }

    private void RateBox()
    {
        GUI.color = Color.white;
        GUI.backgroundColor = Color.white;

        EditorGUILayout.HelpBox("Please Don't Forget To Rate Plugin On Asset Store :)", MessageType.Info);

        buttonContentStyle = new GUIStyle(GUI.skin.button);
        buttonContentStyle.normal.textColor = Color.black;
        buttonContentStyle.fontSize = 15;
        buttonContentStyle.fixedHeight = 25;

        GUI.color = Color.white;
        GUI.backgroundColor = Color.white;

        if (GUILayout.Button("Rate!", buttonContentStyle))
            Application.OpenURL("https://assetstore.unity.com/packages/tools/gui/airy-ui-easy-ui-animation-135898");
    }
}
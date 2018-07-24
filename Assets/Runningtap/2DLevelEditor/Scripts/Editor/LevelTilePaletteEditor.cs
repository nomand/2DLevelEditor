using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace Runningtap
{
    //[CustomEditor(typeof(LevelTilePalette))]
    //public class LevelTilePaletteEditor : Editor
    //{
    //    private SerializedProperty prefabs;

    //    private void OnEnable()
    //    {
    //        prefabs = serializedObject.FindProperty("prefabs");
    //    }

    //    public override void OnInspectorGUI()
    //    {
    //        OnInspectorGUI_Internal(64);
    //    }

    //    private bool IsDeleteKey(Event e)
    //    {
    //        return e.keyCode == KeyCode.Backspace;
    //    }

    //    public static LevelTilePalette AddNew()
    //    {
    //        string path = "Runningtap/Palettes";

    //        if (string.IsNullOrEmpty(path))
    //            path = "Assets";

    //        path = AssetDatabase.GenerateUniqueAssetPath(path + "/New Prefab Palette.asset");

    //        if (!string.IsNullOrEmpty(path))
    //        {
    //            LevelTilePalette palette = ScriptableObject.CreateInstance<LevelTilePalette>();

    //            AssetDatabase.CreateAsset(palette, path);
    //            AssetDatabase.Refresh();

    //            EditorGUIUtility.PingObject(palette);

    //            return palette;
    //        }
    //        return null;
    //    }

    //    public void OnInspectorGUI_Internal(int thumbSize)
    //    {
    //        serializedObject.Update();

    //        int count = prefabs != null ? prefabs.arraySize : 0;

    //        const int margin_x = 8;                 // group pad
    //        const int margin_y = 4;                 // group pad
    //        const int pad = 2;                      // texture pad
    //        const int selected_rect_height = 10;    // the little green bar and height padding

    //        int actual_width = (int)Mathf.Ceil(thumbSize + pad / 2);
    //        int container_width = (int)Mathf.Floor(EditorGUIUtility.currentViewWidth) - (margin_x * 2);
    //        int usable_width = container_width - pad * 2;
    //        int columns = (int)Mathf.Floor(usable_width / actual_width);
    //        int fill = (int)Mathf.Floor(((usable_width % actual_width)) / columns);
    //        int size = thumbSize + fill;
    //        int rows = count / columns + (count % columns == 0 ? 0 : 1);
    //        if (rows < 1) rows = 1;
    //        int height = rows * (size + selected_rect_height);

    //        Rect r = EditorGUILayout.GetControlRect(false, height);

    //        r.x = margin_x + pad;
    //        r.y += margin_y;
    //        r.width = size;
    //        r.height = size;

    //        Rect border = new Rect(margin_x, r.y, container_width, height);

    //        GUI.Box(border, "");

    //        if (count < 1)
    //        {
    //            GUI.Label(border, "Drag Tile Prefabs Here!", EditorStyles.centeredGreyMiniLabel);
    //        }
    //    }
    //}
}
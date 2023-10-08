# if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(Planets))]
public class PlanetEditor : Editor
{
    Planets planet;
    Editor shapeEditor;
    Editor colorEditor;

    public override void OnInspectorGUI() 
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if (check.changed) {
                planet.GeneratePlanet();
            }
        }

        if (GUILayout.Button("Create Your Own Exo Planet")) {
            planet.GeneratePlanet();
            Debug.Log("Generating");

        }

        DrawSettingsEditor(planet.shapeSettings, planet.OnshapeSettingsUpdated , ref planet.shapeSettingsFoldout , ref shapeEditor);
        DrawSettingsEditor(planet.colorSettings, planet.OnColorSettingsUpdated , ref planet.colorSettingsFoldout , ref colorEditor);
    }


    void DrawSettingsEditor(Object settings , System.Action onSettingsUpdated ,ref bool foldout , ref Editor editor)
    {

        foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            EditorGUILayout.InspectorTitlebar(true, settings);

            if (foldout)
            {
                if (settings != null)
                {
                    CreateCachedEditor(settings, null, ref editor);
                    editor.OnInspectorGUI();

                    if (check.changed)
                    {
                        if (onSettingsUpdated != null)
                        {
                            onSettingsUpdated();
                        }
                    }
                }
            }
        }
    }

    private void OnEnable() 
    {
        planet = (Planets)target;  
    }
}
#endif
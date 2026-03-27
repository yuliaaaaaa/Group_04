using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;

public class LevelEditorTool : EditorWindow
{
    public GameObject ObjectToPlace;
    private bool _canPlace;
    private float _placementCallDown = 1f;
    private float _timeSinceLastPlacement = 0f;

    [MenuItem("Tools/Level Editor")]
    public static void ShowWindow()
    {
        GetWindow<LevelEditorTool>("Level Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Level Editor Tool", EditorStyles.boldLabel);

        ObjectToPlace = (GameObject)EditorGUILayout.ObjectField("Object to Place:", ObjectToPlace, typeof(GameObject), false);

        if (GUILayout.Button("Toggle Placement"))
        {
            _canPlace = !_canPlace;
        }

        if (GUILayout.Button("Reset Placement"))
        {
            _canPlace = true;
        }

        if (ObjectToPlace)
        {
            SceneView.duringSceneGui += OnSceneGUI;
            Debug.Log("ПІДПИСКА");
        }
        else
        {
            SceneView.duringSceneGui -= OnSceneGUI;
            Debug.Log("ВІДПИСКА");
        }
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0 && _canPlace)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(ObjectToPlace, hit.point, Quaternion.identity);
                _canPlace = false;
                _timeSinceLastPlacement = 0f;
                EditorApplication.update += UpdatePlacementCooldown;
            }

            sceneView.Repaint();
        }
    }
    private void UpdatePlacementCooldown()
    {
        _timeSinceLastPlacement += Time.deltaTime;

        if (_timeSinceLastPlacement >= _placementCallDown)
        {
            _canPlace = true;
            EditorApplication.update -= UpdatePlacementCooldown;
        }
    }
    private void OnDestroy()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
        EditorApplication.update -= UpdatePlacementCooldown;
    }

}

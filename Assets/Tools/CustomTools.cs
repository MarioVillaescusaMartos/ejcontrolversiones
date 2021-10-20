using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class CustomToolsExercise : MonoBehaviour
{
    //Properties
    private static Vector3 copyLocalCoordinates;
    private static Vector3 copyLocalScale;
    private static Vector3 copyLocalRotation;
    private static float scaleCube;
    private static float rotateCube;

    private static int distribution = 0;
    private static int distributionDistanceStair = 1;
    private static int distributionDistance = 5;
    private static int height = 0;
    private static int letsUp = 1;
    private static float minScale = 0.5f;
    private static float maxScale = 3;
    private static float minRot = 0;
    private static float maxRot = 360;

    //Tramsforms de posición
    [MenuItem("EjercicioAutomaticacion//Copy coordinates", false, 1)]
    public static void CopyCoordinates()
    {
        Transform pieza = Selection.activeTransform;

        if (pieza != null)
        {
            copyLocalCoordinates = pieza.localPosition;
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    [MenuItem("EjercicioAutomaticacion//Propuestas/Transform/Paste coordinates", false, 1)]
    public static void PasteCoordinates()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                pieza[i].localPosition = copyLocalCoordinates;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    //Aliniaciones en los ejes X, Y, Z
    [MenuItem("EjercicioAutomaticacion//Propuestas/Align/To X", false, 1)]
    public static void AlignToX()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                Vector3 p = pieza[i].localPosition;
                p = new Vector3(copyLocalCoordinates.x, p.y, p.z);
                pieza[i].localPosition = p;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    [MenuItem("EjercicioAutomaticacion//Propuestas/Align/To Y", false, 1)]
    public static void AlignToY()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                Vector3 p = pieza[i].localPosition;
                p = new Vector3(p.x, copyLocalCoordinates.y, p.z);
                pieza[i].localPosition = p;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    [MenuItem("EjercicioAutomaticacion//Propuestas/Align/To Z", false, 1)]
    public static void AlignToZ()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                Vector3 p = pieza[i].localPosition;
                p = new Vector3(p.x, p.y, copyLocalCoordinates.z);
                pieza[i].localPosition = p;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    //Distribuciones de objetos en los ejes X, Y, Z con separación fija
    [MenuItem("EjercicioAutomaticacion//Propuestas/Distrubute/On X", false, 1)]
    public static void DistributeOnX()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);
        distribution = 0;

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                distribution = distribution + distributionDistance;
                Vector3 p = pieza[i].localPosition;
                p = new Vector3(copyLocalCoordinates.x + distribution, p.y, p.z);
                pieza[i].localPosition = p;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    [MenuItem("EjercicioAutomaticacion//Propuestas/Distrubute/On Y", false, 1)]
    public static void DistributeOnY()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);
        distribution = 0;

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                distribution = distribution + distributionDistance;

                Vector3 p = pieza[i].localPosition;
                p = new Vector3(p.x, copyLocalCoordinates.y + distribution, p.z);
                pieza[i].localPosition = p;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    [MenuItem("EjercicioAutomaticacion//Propuestas/Distrubute/On Z", false, 1)]
    public static void DistributeOnZ()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);
        distribution = 0;

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                distribution = distribution + distributionDistance;

                Vector3 p = pieza[i].localPosition;
                p = new Vector3(p.x, p.y, copyLocalCoordinates.z + distribution);
                pieza[i].localPosition = p;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    //Crear un padre para una selecciones de objetos
    [MenuItem("EjercicioAutomaticacion//Propuestas/Create parent for selection", false, 1)]
    public static void CreateParentForSelection()
    {
        Transform[] selection = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (selection.Length > 0)
        {
            GameObject parent = new GameObject("Parent");

            for (int i = 0; i < selection.Length; i++)
            {
                selection[i].parent = parent.transform;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Tienes que seleccionar un objeto ", "OK");
        }
    }

    //Propias
    [MenuItem("EjercicioAutomaticacion//Propias/Random size", false, 1)]
    public static void RandomSize()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                scaleCube = UnityEngine.Random.Range(minScale, maxScale);
                float t = scaleCube;

                Vector3 p = pieza[i].localScale;
                p = new Vector3(t, t, t);
                pieza[i].localScale = p;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    [MenuItem("EjercicioAutomaticacion//Propias/Scale transform/Copy size", false, 1)]
    public static void CopyScale()
    {
        Transform pieza = Selection.activeTransform;

        if (pieza != null)
        {
            copyLocalScale = pieza.localScale;
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    [MenuItem("EjercicioAutomaticacion//Propias/Scale transform/Paste size", false, 1)]
    public static void PasteScale()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                pieza[i].localScale = copyLocalScale;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    [MenuItem("EjercicioAutomaticacion//Propias/Random rotation/On X", false, 1)]
    public static void RandomRotateOnX()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                rotateCube = UnityEngine.Random.Range(minRot, maxRot);
                float t = rotateCube;

                pieza[i].Rotate(t, 0, 0);
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    [MenuItem("EjercicioAutomaticacion//Propias/Random rotation/On Y", false, 1)]
    public static void RandomRotateOnY()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                rotateCube = UnityEngine.Random.Range(minRot, maxRot);
                float t = rotateCube;

                pieza[i].Rotate(0, t, 0);
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    [MenuItem("EjercicioAutomaticacion//Propias/Random rotation/On Z", false, 1)]
    public static void RandomRotateOnZ()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                rotateCube = UnityEngine.Random.Range(minRot, maxRot);
                float t = rotateCube;

                pieza[i].Rotate(0, 0, t);
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    [MenuItem("EjercicioAutomaticacion//Propias/Made stair/On Z", false, 1)]
    public static void MadeStairsZ()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);
        distribution = 0;
        height = 0;

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                distribution = distribution + distributionDistanceStair;
                Vector3 p = pieza[i].localPosition;
                p = new Vector3(p.x, p.y, copyLocalCoordinates.z + distribution);
                pieza[i].localPosition = p;

                height = height + letsUp;
                Vector3 k = pieza[i].localScale;
                k = new Vector3(1, height, 1);
                pieza[i].localScale = k;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }

    [MenuItem("EjercicioAutomaticacion//Propias/Made stair/On X", false, 1)]
    public static void MadeStairsX()
    {
        Transform[] pieza = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.Editable);
        distribution = 0;
        height = 0;

        if (pieza.Length > 0)
        {
            for (int i = 0; i < pieza.Length; i++)
            {
                distribution = distribution + distributionDistanceStair;
                Vector3 p = pieza[i].localPosition;
                p = new Vector3(copyLocalCoordinates.x + distribution, p.y, p.z);
                pieza[i].localPosition = p;

                height = height + letsUp;
                Vector3 k = pieza[i].localScale;
                k = new Vector3(1, height, 1);
                pieza[i].localScale = k;
            }
        }
        else
        {
            EditorUtility.DisplayDialog("Error", "Primero hay que seleccionar un objeto ", "OK");
        }
    }
}
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShopSystem))]
public class ShopElementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ShopSystem shopSystem = (ShopSystem)target;

        // Display a button to add a new shop element
        if (GUILayout.Button("Add Shop Element"))
        {
            shopSystem.AddShopElement(new ShopElement());
        }

        // Display each shop element with a remove button
        for (int i = 0; i < shopSystem.shopElements.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            shopSystem.shopElements[i] = (ShopElement)EditorGUILayout.ObjectField("Shop Element " + i, shopSystem.shopElements[i], typeof(ShopElement), false);
            if (GUILayout.Button("Remove"))
            {
                shopSystem.RemoveShopElement(i);
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}

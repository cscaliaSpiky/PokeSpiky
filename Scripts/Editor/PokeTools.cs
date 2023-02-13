using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class PokeTools
{
    static PokeTools()
    {
        AssetDatabase.importPackageCompleted -= OnImportPackageCompleted;
        AssetDatabase.importPackageCompleted += OnImportPackageCompleted;
    }
    
    [MenuItem("Spiky Tools/Poke/Initial Setup")]
    private static void StartInitialSetupTool1()
    {
        PlayerSettings.applicationIdentifier = "com.spiky."+ Application.productName.ToLower().Replace(" ","");
        AssetDatabase.ImportPackage("Assets/PokeCore/Packages/BasicScenesAndScripts.unitypackage", false);
        AssetDatabase.SaveAssets();
    }

    private static void OnImportPackageCompleted(string obj)
    {
        if (obj.Equals("BasicScenesAndScripts"))
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            AssetDatabase.MoveAsset("Assets/_GameName", "Assets/"+ GameFolderName);
        }
    }
    
    [MenuItem("Spiky Tools/Poke/Update Init Package")]
    private static void UpdateInitPackage()
    {
        AssetDatabase.MoveAsset("Assets/"+ GameFolderName, "Assets/_GameName");
        string[] assets = { "Assets/_GameName" };
        AssetDatabase.ExportPackage(assets, "Assets/PokeCore/Packages/BasicScenesAndScripts.unitypackage", ExportPackageOptions.Recurse);
        AssetDatabase.MoveAsset("Assets/_GameName", "Assets/"+ GameFolderName);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
        
    static string  GameFolderName => "_" + Application.productName.Replace(" ", string.Empty);
}

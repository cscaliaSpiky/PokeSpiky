using UnityEditor;
using UnityEngine;

public class PokeTools
{
    [MenuItem("Spiky Tools/Poke/Initial Setup 1")]
    private static void StartInitialSetupTool1()
    {
        PlayerSettings.applicationIdentifier = "com.spiky."+ Application.productName.ToLower().Replace(" ","");
        AssetDatabase.ImportPackage("Assets/PokeCore/Packages/BasicScenesAndScripts.unitypackage", false);
        AssetDatabase.SaveAssets();
    }
    
    [MenuItem("Spiky Tools/Poke/Initial Setup 2")]
    private static void StartInitialSetupTool2()
    {
        string gameFolderName = "_" + Application.productName.Replace(" ", string.Empty);
        AssetDatabase.MoveAsset("Assets/_GameName", "Assets/"+ gameFolderName);
        AssetDatabase.SaveAssets();
    }
}

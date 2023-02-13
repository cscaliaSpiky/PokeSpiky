using UnityEngine;

namespace PokeSpiky
{
    public class LevelSpeedUpCheat : MonoBehaviour
    {
        private void Update()
        {
            if (!Application.isEditor)
                return;

            if (Input.GetKeyDown(KeyCode.Q))
                ModifyLevel(-1);
            if (Input.GetKeyDown(KeyCode.E))
                ModifyLevel(1);
            if (Input.GetKeyDown(KeyCode.R))
                DefaultGameEventSystemManager.Instance.GameEventSystem.Dispatch(new ForceReloadLevelEvent());
            if (Input.GetKeyDown(KeyCode.Space))
                Time.timeScale = 3;
            else if (Input.GetKeyUp(KeyCode.Space))
                Time.timeScale = 1;
        }
        
        private static void ModifyLevel(int levelAdd)
        {
            DefaultGameEventSystemManager.Instance.GameEventSystem.Dispatch(new ForceOverrideUserLevelEvent(levelAdd));
            UpdateService.Instance.CancelAction(ReloadScene);
            UpdateService.Instance.ExecuteActionAfterSeconds(.25f, ReloadScene);
        }

        private static void ReloadScene()
        {
            DefaultGameEventSystemManager.Instance.GameEventSystem.Dispatch(new ForceReloadLevelEvent());
        }
    }
}
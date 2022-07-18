using System.Collections.Generic;
//using DG.Tweening;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public RectTransform hudTransform;

    private float activePosition;
    private float hidePosition;

    public List<GameObject> objectsToHide;
    
    private void Start()
    {
        //GameOverCondition.instance.OnGameOver += OnGameOver;
        DebugMenu.Instance.OnDebugMenuOpened += OnDebugMenuOpened;
        activePosition = hudTransform.localPosition.x;
        hidePosition = hudTransform.localPosition.x - hudTransform.rect.width;
    }

    public void ToggleUI()
    {
        objectsToHide.ForEach(go=> go.SetActive(!go.activeSelf));
    }
        
    private void OnDebugMenuOpened(bool isOpen)
    {
        SetActive(!isOpen);
    }

    private void OnGameOver(bool active)
    {
        SetActive(false);
    }

    void SetActive(bool active)
    {
        // if (active)
        // {
        //     hudTransform.DOLocalMoveX(activePosition, .3f);
        // }
        // else
        // {
        //     hudTransform.DOLocalMoveX(hidePosition, .3f);
        // }
    }

    private void OnDestroy()
    {
        DebugMenu.Instance.OnDebugMenuOpened -= OnDebugMenuOpened;
    }
}

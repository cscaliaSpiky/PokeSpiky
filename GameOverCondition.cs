using System;


public class GameOverCondition
{
    public static GameOverCondition instance;

    public BasePopUp winPopup;
    public BasePopUp losePopup;
    
    public Action<bool> OnGameOver;

    private bool used;
    
    public GameOverCondition(BasePopUp winPopup, BasePopUp losePopup)
    {
        instance = this;
        this.winPopup = winPopup;
        this.losePopup = losePopup;
    }
    
    public void Win(float delay = 0)
    {
        if (used)
            return;
        used = true;
        UpdateService.Instance.ExecuteActionAfterSeconds(delay, OpenSuccessPopup);
        OnGameOver?.Invoke(true);
    }

    public void Lose(float delay = 0)
    {
        if (used)
            return;
        UpdateService.Instance.ExecuteActionAfterSeconds(delay, OpenFailedPopup);
        OnGameOver?.Invoke(false);
        used = true;
    }
    
    private void OpenSuccessPopup()
    {
        UIService.Instance.OpenPopup(winPopup);
    }

    private void OpenFailedPopup()
    {
        UIService.Instance.OpenPopup(losePopup);
    }
}


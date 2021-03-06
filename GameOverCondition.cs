using System;


public class GameOverCondition
{
    public static GameOverCondition instance;

    public IPopUp winPopup;
    public IPopUp losePopup;
    
    public Action<bool> OnGameOver;

    private bool used;
    
    public GameOverCondition(IPopUp winPopup, IPopUp losePopup)
    {
        instance = this;
        this.winPopup = winPopup;
        this.losePopup = losePopup;
    }
    
    public void Win()
    {
        if (used)
            return;
        used = true;
        UpdateService.Instance.ExecuteActionAfterSeconds(2, OpenSuccessPopup);
        OnGameOver?.Invoke(true);
    }

    public void Lose()
    {
        if (used)
            return;
        UpdateService.Instance.ExecuteActionAfterSeconds(2, OpenFailedPopup);
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


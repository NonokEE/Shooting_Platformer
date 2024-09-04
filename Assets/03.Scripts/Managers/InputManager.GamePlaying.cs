using UnityEngine;

public partial class InputManager
{
    private void OnUpdate_GamePlaying()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Inst.State = GameManager.GameState.GamePause;
            Debug.Log(GameManager.Inst.State);
        }
    }
}
using UnityEngine;

public partial class InputManager
{
    private void OnUpdate_GamePause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Inst.State = GameManager.GameState.GamePlaying;
            Debug.Log(GameManager.Inst.State);
        }
    }
}
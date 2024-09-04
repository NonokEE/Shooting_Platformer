using UnityEngine;

public partial class InputManager
{
    private void OnUpdate_GamePlaying()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Singleton<GameManager>.Inst.State = GameManager.GameState.GamePause;
            Debug.Log(Singleton<GameManager>.Inst.State);
        }
    }
}
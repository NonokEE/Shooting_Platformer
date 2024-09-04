using UnityEngine;

public partial class InputManager
{
    private void OnUpdate_GamePause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Singleton<GameManager>.Inst.State = GameManager.GameState.GamePlaying;
            Debug.Log(Singleton<GameManager>.Inst.State);
        }
    }
}
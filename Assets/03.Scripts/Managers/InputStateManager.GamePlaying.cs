using UnityEngine;

public partial class InputStateManager
{
    private void OnUpdate_GamePlaying()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Singleton<GameManager>.Inst.State = GameManager.GameState.GamePause;
            Debug.Log(Singleton<GameManager>.Inst.State);
        }
    }
}
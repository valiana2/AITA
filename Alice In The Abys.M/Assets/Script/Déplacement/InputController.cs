using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;

namespace RPGM.UI
{
    /// <summary>
    /// Sends user input to the correct control systems.
    /// </summary>
    public class InputController : MonoBehaviour
    {
        public float stepSize = 0.1f;
        GameModel model = Schedule.GetModel<GameModel>();

        public enum State
        {
            CharacterControl,
            Pause
        }

        State state;

        public void ChangeState(State state) => this.state = state;

        void Update()
        {
            switch (state)
            {
                case State.CharacterControl:
                    CharacterControl();
                    break;
            }
        }


        void CharacterControl()
        {
            if (Input.GetKey(KeyCode.UpArrow))
                model.player.next= Vector3.up * stepSize;
            else if (Input.GetKey(KeyCode.DownArrow))
                model.player.next = Vector3.down * stepSize;
            else if (Input.GetKey(KeyCode.LeftArrow))
                model.player.next = Vector3.left * stepSize;
            else if (Input.GetKey(KeyCode.RightArrow))
                model.player.next = Vector3.right * stepSize;
            else
                model.player.next = Vector3.zero;
        }
    }
}
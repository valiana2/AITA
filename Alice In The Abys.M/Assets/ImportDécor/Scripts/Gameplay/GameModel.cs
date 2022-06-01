using System;
using System.Collections;
using System.Collections.Generic;
using RPGM.Core;
using RPGM.Gameplay;
using RPGM.UI;
using UnityEngine;

namespace RPGM.Gameplay
{
    /// <summary>
    /// This class provides all the data you need to control and change gameplay.
    /// </summary>
    [Serializable]
    public class GameModel
    {
        public CharacterController2D player;
        public InputController input;
    }
}
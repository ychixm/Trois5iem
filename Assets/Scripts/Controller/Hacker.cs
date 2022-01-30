using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    /// <summary>
    /// Player Controller for the  hacker player
    /// </summary>
    public class HackerPlayerController : MonoBehaviour
    {
        #region Properties

        /// <summary>
        /// The game game state 
        /// </summary>
        public bool isPaused;
    
        #endregion

        #region Methods

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        public void Update()
        {
            if (isPaused) {
                return;
            }

            if (Input.GetKeyDown(HackerControlKey.keyTrapOne)) {
                ObstacleManager.Instance.OnAction(ObstacleManager.Control.A);
            }
            if (Input.GetKeyDown(HackerControlKey.keyTrapTwo)) {
                ObstacleManager.Instance.OnAction(ObstacleManager.Control.B);
            }
            if (Input.GetKeyDown(HackerControlKey.keyTrapThree)) {
                ObstacleManager.Instance.OnAction(ObstacleManager.Control.X);
            }
            if (Input.GetKeyDown(HackerControlKey.keyTrapFour)) {
                ObstacleManager.Instance.OnAction(ObstacleManager.Control.Y);
            }

        }

        #endregion
    
    }
}

public class HackerControlKey : MonoBehaviour {
    public static readonly KeyCode keyTrapOne = KeyCode.U;
    public static readonly KeyCode keyTrapTwo = KeyCode.I;
    public static readonly KeyCode keyTrapThree = KeyCode.O;
    public static readonly KeyCode keyTrapFour = KeyCode.P;
}

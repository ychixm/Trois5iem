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
        public bool IsPaused { get; set; }

        /// <summary>
        /// List of traps controlled by the player
        /// </summary>
        public List<Obstacle> ObstacleList { get; set; }
    
        #endregion

        #region Methods

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        public void Update()
        {
            if (IsPaused)
            {
                return;
            }

            if (Input.GetKeyDown(HackerControlKey.keyTrapOne))
            {
                ObstacleList[0]?.ExecuteAction();
            }
            if (Input.GetKeyDown(HackerControlKey.keyTrapTwo))
            {
                ObstacleList[1]?.ExecuteAction();
            }
            if (Input.GetKeyDown(HackerControlKey.keyTrapThree))
            {
                ObstacleList[2]?.ExecuteAction();
            }
            if (Input.GetKeyDown(HackerControlKey.keyTrapFour))
            {
                ObstacleList[3]?.ExecuteAction();
            }

        }

        #endregion
    
    }
}

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

        /// <summary>
        /// List of traps controlled by the player
        /// </summary>
        public List<Obstacle> obstacleList;
    
        #endregion

        #region Methods

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        public void Update()
        {
            if (isPaused)
            {
                return;
            }

            if (Input.GetKeyDown(HackerControlKey.keyTrapOne))
            {
                obstacleList[0]?.ExecuteAction();
            }
            if (Input.GetKeyDown(HackerControlKey.keyTrapTwo))
            {
                obstacleList[1]?.ExecuteAction();
            }
            if (Input.GetKeyDown(HackerControlKey.keyTrapThree))
            {
                obstacleList[2]?.ExecuteAction();
            }
            if (Input.GetKeyDown(HackerControlKey.keyTrapFour))
            {
                obstacleList[3]?.ExecuteAction();
            }

        }

        #endregion
    
    }
}

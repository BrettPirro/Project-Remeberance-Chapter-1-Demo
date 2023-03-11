using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectR.SceneManagment
{
    public class PersitantOBJSpawner : MonoBehaviour
    {
        [SerializeField] GameObject persistantOBJ;
        static bool spawned;
        private void Awake()
        {
            if (spawned == false)
            {
                GameObject persOBJ = Instantiate(persistantOBJ, transform.position, transform.rotation) as GameObject;
                DontDestroyOnLoad(persOBJ);
                spawned = true;
            }

        }
    }
}

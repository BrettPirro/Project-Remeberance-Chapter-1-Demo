using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ProjectR.SceneManagment;

namespace ProjectR.UI 
{
    public class GenDotPosManager : MonoBehaviour
    {
        [SerializeField] Vector2 PosToReach;
        [SerializeField] Vector2 CurrentPos;
        [SerializeField] GameObject[] Points;
        [SerializeField] GameObject Player;
        [SerializeField] AudioClip EngineSound;
        bool Finished = false;
        public void UpdatePosX(float X)
        {
            if (Finished) { return; }
            CurrentPos.x += X;
            Debug.Log("worked");
            if ((CurrentPos.x < 0)) { CurrentPos.x = 0; }
            else if ((CurrentPos.x > 3)) { CurrentPos.x = 3; }
            UpdatePosition();
            IsOnPoint();

        }

        public void UpdatePosY(float Y)
        {
            if (Finished) { return; }
            CurrentPos.y += Y;
            Debug.Log("worked");
            if ((CurrentPos.y < 0)) { CurrentPos.y = 0; }
            else if ((CurrentPos.y > 2)) { CurrentPos.y = 2; }
            UpdatePosition();
            IsOnPoint();
        }

        private void IsOnPoint()
        {
            if (CurrentPos == PosToReach && !Finished)
            {
                StartCoroutine(GenStartUp());
            }
        }

        private void UpdatePosition()
        {
            if (CurrentPos == new Vector2(0, 0))
            {
                Player.GetComponent<RectTransform>().position = Points[0].GetComponent<RectTransform>().position;
            }
            else if (CurrentPos == new Vector2(1, 0))
            {
                Player.GetComponent<RectTransform>().position = Points[1].GetComponent<RectTransform>().position;
            }
            else if (CurrentPos == new Vector2(2, 0))
            {
                Player.GetComponent<RectTransform>().position = Points[2].GetComponent<RectTransform>().position;
            }
            else if (CurrentPos == new Vector2(3, 0))
            {
                Player.GetComponent<RectTransform>().position = Points[3].GetComponent<RectTransform>().position;
            }
            else if (CurrentPos == new Vector2(0, 1))
            {
                Player.GetComponent<RectTransform>().position = Points[4].GetComponent<RectTransform>().position;
            }
            else if (CurrentPos == new Vector2(1, 1))
            {
                Player.GetComponent<RectTransform>().position = Points[5].GetComponent<RectTransform>().position;
            }
            else if (CurrentPos == new Vector2(2, 1))
            {
                Player.GetComponent<RectTransform>().position = Points[6].GetComponent<RectTransform>().position;
            }
            else if (CurrentPos == new Vector2(3, 1))
            {
                Player.GetComponent<RectTransform>().position = Points[7].GetComponent<RectTransform>().position;
            }
            else if (CurrentPos == new Vector2(0, 2))
            {
                Player.GetComponent<RectTransform>().position = Points[8].GetComponent<RectTransform>().position;
            }
            else if (CurrentPos == new Vector2(1, 2))
            {
                Player.GetComponent<RectTransform>().position = Points[9].GetComponent<RectTransform>().position;
            }
            else if (CurrentPos == new Vector2(2, 2))
            {
                Player.GetComponent<RectTransform>().position = Points[10].GetComponent<RectTransform>().position;
            }
            else if (CurrentPos == new Vector2(3, 2))
            {
                Player.GetComponent<RectTransform>().position = Points[11].GetComponent<RectTransform>().position;
            }



        }

        IEnumerator GenStartUp()
        {
            Finished = true;
            AudioSource.PlayClipAtPoint(EngineSound, Camera.main.transform.position);
            yield return new WaitForSeconds(1f);
            FindObjectOfType<SceneManage>().LoadTheNextScene();
        }

    }

}
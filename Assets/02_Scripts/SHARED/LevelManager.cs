using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //public Animator transition;
    public float transitionTime = 1f;
    public ActivarBody body;

    void Update() {
        if (Input.GetKey("space"))//(Input.GetMouseButtonDown(0))
        {
            Debug.Log("next");
            LoadNextLevel();
            body.Apagar();
        }
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) {
        //transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        UnityEngine.SceneManagement.SceneManager.LoadScene(levelIndex);

    }
}

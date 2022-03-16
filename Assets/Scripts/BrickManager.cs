using UnityEngine;

public class BrickManager : MonoBehaviour
{
    private GameObject _bundle;
    private LevelManager _levelManager;

    private void Start()
    {
        _bundle = GameObject.FindWithTag("BrickBundle");
        _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void Update()
    {
        CheckBricks();
    }

    private void CheckBricks()
    {
        var brickCount = 0;
        foreach (Transform child in _bundle.transform)
        {
            if (child.gameObject.activeInHierarchy)
            {
                brickCount++;
            }
        }

        if (brickCount == 0)
        {
            _levelManager.LoadNextLevel();
        }
    }
}
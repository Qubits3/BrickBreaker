using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    private float _locX = -6;
    private float _locY = 3;

    private void Start()
    {
        SpawnBrick();
    }

    private void SpawnBrick()
    {
        if (ObjectPooler.SharedInstance.GetPooledObject() != null)
        {
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    var brick = ObjectPooler.SharedInstance.GetPooledObject();
                    brick.transform.position = new Vector3(_locX, _locY);
                    _locX += 1.5f;
                    brick.SetActive(true);
                }

                _locY += 0.6f;
                _locX = -6;
            }
        }
        else
        {
            Invoke(nameof(SpawnBrick), 1.0f);
        }
    }
}
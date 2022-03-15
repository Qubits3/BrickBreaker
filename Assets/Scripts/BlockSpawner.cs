using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    private float _locX = -6;
    private float _locY = 3;

    private void Start()
    {
        SpawnBlock();
    }

    private void SpawnBlock()
    {
        if (ObjectPooler.SharedInstance.GetPooledObject() != null)
        {
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    var block = ObjectPooler.SharedInstance.GetPooledObject();
                    block.transform.position = new Vector3(_locX, _locY);
                    _locX += 1.5f;
                    block.SetActive(true);
                }

                _locY += 0.6f;
                _locX = -6;
            }
        }
        else
        {
            Invoke(nameof(SpawnBlock), 1.0f);
        }
    }
}
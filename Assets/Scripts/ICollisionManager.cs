using System.Collections;
using UnityEngine;

public interface ICollisionManager
{
    IEnumerator OnBallCollided(GameObject collidedObject);
}
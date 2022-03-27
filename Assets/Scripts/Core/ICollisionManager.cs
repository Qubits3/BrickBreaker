using System.Collections;
using UnityEngine;

namespace Core
{
    public interface ICollisionManager
    {
        IEnumerator OnBallCollided(GameObject collidedObject);
    }
}
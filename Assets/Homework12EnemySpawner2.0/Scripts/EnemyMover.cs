using UnityEngine;

namespace Homework12
{
    public class EnemyMover : MonoBehaviour
    {
        public void PurseTarget(float speed, Target target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }
    }
}

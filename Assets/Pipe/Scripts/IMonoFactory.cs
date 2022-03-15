using UnityEngine;

public interface IMonoFactory<out T> where T : MonoBehaviour
{
    T Create(Vector3 position);
}
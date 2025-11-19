using UnityEngine;


public interface IInteractable
{
    void Interact(GameObject observer);
    void OnPlayerEnter();
    void OnPlayerExit();
}
public interface IEnemy
{
    void ChasePlayer();
    void StopChasing();
    void Attack();
}
public interface IDamageable
{
    void TakeDamage(float amount);
}
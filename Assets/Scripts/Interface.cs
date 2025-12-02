using UnityEngine;

// Este script define interfaces para objetos interactuables (IInteractable), enemigos (IEnemy) y objetos que pueden recibir daño (IDamageable).
// Relación con otros scripts:
// BaseInteractable implementa IInteractable.
// Los enemigos podrían implementar IEnemy o IDamageable para definir comportamientos específicos.
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
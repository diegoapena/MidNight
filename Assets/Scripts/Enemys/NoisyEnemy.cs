using UnityEngine;

public class NoisyEnemy : BaseEntity
{
    
      new void Start()
    {
        PlayAppearSound();
    }


    private void PlayAppearSound()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySound("NoisyAppear", 1f);
        }
    }
}

using UnityEngine;

public class AnimatorReset : MonoBehaviour
{
    [SerializeField] Animator anim;
    
    public void HitReset()
    {
        anim.SetBool("Hit", false);
    }
}

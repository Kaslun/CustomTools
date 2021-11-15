using System.Collections;
using UnityEngine;
using Manager;

public class Button : MonoBehaviour, IInteract
{

    public Transform door = null;
    private Animator anim;
    public float delayTimer;

    [Header("Color Properties")]
    public bool isColorButton;
    public AnimationCurve animCurve;

    void Start()
    {
        if (TryGetComponent(out Animator _anim))
            anim = _anim;
        else
        {
            anim = null;
        }
    }

    public void DoInteract()
    {
        if(isColorButton)
            FindObjectOfType<ColorFilterManager>().SendMessage("UpdateColorFilter", animCurve);
        else
        {
            anim.SetBool("isActivated", true);
            door.GetComponent<Animator>().SetBool("isActivated", true);
        }
    }

    public IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(delayTimer);
        anim.SetBool("isActivated", false);
        door.GetComponent<Animator>().SetBool("isActivated", false);
    }
}

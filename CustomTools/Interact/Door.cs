using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

[RequireComponent(typeof(Animator))]
public class Door : InteractBase
{
    private Animator _anim;
    public bool isOpen;
    public bool needKey = false;
    public bool hasKey;

    public Material lockedMat;
    public Material unlockedMat;

    public void Start()
    {
        _anim = GetComponent<Animator>();
        if (needKey && !hasKey)
        {
            GetComponent<Renderer>().material = lockedMat;
        }
        else
            GetComponent<Renderer>().material = unlockedMat;
    }

    public override void DoInteract()
    {
        if (needKey)
        {
            if (hasKey)
            {
                isOpen = !isOpen;
                _anim.SetBool("isOpen", isOpen);
                print("opening door");
            }
            else
                print("Need key!");
        }
        else
        {
            isOpen = !isOpen;
            _anim.SetBool("isOpen", isOpen);
            print("opening door");
        }
    }

    public void PickedUpKey()
    {
        hasKey = true;
        GetComponent<Renderer>().material = unlockedMat;
    }
}

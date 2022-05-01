using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public bool isOpen   = false;
    public bool isLocked = false;

    public AkRoomPortal portal;
    private Animator anim;
    private Player player;

    protected override void Start()
    {
        base.Start();

        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();

        if (isOpen) Open();
        if (isLocked) Lock();

        onInteract.AddListener(DoorInteract);
    }

    private void DoorInteract()
    {
        isOpen = !isOpen;

        if (isOpen) Open();
        else Close();

        print("door: " + isOpen);
    }

    public void Lock()
    {
        isLocked = true;
        anim.SetBool("Locked", true);
    }

    public void Unlock()
    {
        isLocked = false;
        anim.SetBool("Locked", false);
    }

    public void Open()
    {
        if (isLocked && player.hasKey)
        {
            Unlock();
        }
        else if (isLocked)
        {
            isOpen = false;
            return;
        }

        isOpen = true;
        portal.Open();
        anim.SetTrigger("Open");
    }

    public void Close()
    {
        isOpen = false;
        portal.Close();
        anim.SetTrigger("Close");
    }
}

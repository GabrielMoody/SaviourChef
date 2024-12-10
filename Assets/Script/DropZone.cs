using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    public Customer customer;

    public void awake()
    {
        customer = GetComponent<Customer>();
    }
}

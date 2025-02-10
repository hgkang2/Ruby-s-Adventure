using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagezone : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
   {
    //RubyController controller = other.GetComponent<RubyController>();
    //if (controller != null)
    if (other.TryGetComponent<RubyController>(out var controller))
    {
        controller.ChangeHealth(-1);
    }
   }
}

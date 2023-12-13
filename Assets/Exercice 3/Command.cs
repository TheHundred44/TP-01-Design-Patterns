using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : MonoBehaviour
{   
        public abstract void Execute();
        public abstract void Undo();
        public abstract void Redo();

        public abstract bool IsSuccessful { get; set; }
}

using UnityEngine;
public interface IStackable 
{
    int MaxStack { get; }
    int CurrentStack { get; set; }
}
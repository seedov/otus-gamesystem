using System;
using UnityEngine;


public interface IKeyboardInputConfig
{
    KeyCode Up { get; }
    KeyCode Right { get; }
    KeyCode Left { get; }
    KeyCode Down { get; }
}

[Serializable]
public class KeyboardInputConfig : IKeyboardInputConfig
{
    [SerializeField]
    private KeyCode up;

    [SerializeField]
    private KeyCode left;
    [SerializeField]
    private KeyCode down;
    [SerializeField]
    private KeyCode right;

    public KeyCode Up => up;

    public KeyCode Right => right;

    public KeyCode Left => left;

    public KeyCode Down => down;
}
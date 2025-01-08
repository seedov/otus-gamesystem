using System;
using UnityEngine;




[CreateAssetMenu(fileName = "InputConfig", menuName = "Scriptable Objects/InputConfig")]
public class InputConfig : ScriptableObject
{
    [SerializeField]
    private KeyboardInputConfig keyboardInputConfig;

    public IKeyboardInputConfig KeyboardInputConfig => keyboardInputConfig;

}

public interface IKeyboardInputConfig
{
    public KeyCode Up { get; }
    public KeyCode Left { get; }
    public KeyCode Down { get; }
    public KeyCode Right { get; }
}


[Serializable]
public class KeyboardInputConfig : IKeyboardInputConfig
{
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode right;

    public KeyCode Up => up;

    public KeyCode Left => left;

    public KeyCode Down => down;

    public KeyCode Right => right;
}

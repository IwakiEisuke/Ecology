using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

public class DisallowOneModifierAxisComposite : InputBindingComposite<float>
{
    [InputControl(layout = "Button")] public int modifier;
    [InputControl(layout = "Axis")] public int positive;
    [InputControl(layout = "Axis")] public int negative;

    public bool invertDisallow;

    /// <summary>
    /// èâä˙âª
    /// </summary>
#if UNITY_EDITOR
    [UnityEditor.InitializeOnLoadMethod]
#else
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#endif
    private static void Initialize()
    {
        // èââÒÇ…CompositeBindingÇìoò^Ç∑ÇÈïKóvÇ™Ç†ÇÈ
        InputSystem.RegisterBindingComposite(typeof(DisallowOneModifierVector2Composite), nameof(DisallowOneModifierVector2Composite));
    }

    public enum Mode
    {
        Analog = 2,
        DigitalNormalized = 0,
        Digital = 1
    }

    public Mode mode;

    public override float ReadValue(ref InputBindingCompositeContext context)
    {
        if (!context.ReadValueAsButton(modifier) != invertDisallow)
        {
            var mode = this.mode;

            if (mode == Mode.Analog)
            {
                var upValue = context.ReadValue<float>(positive);
                var downValue = context.ReadValue<float>(negative);

                return upValue - downValue;
            }

            var upIsPressed = context.ReadValueAsButton(positive);
            var downIsPressed = context.ReadValueAsButton(negative);

            return upIsPressed && downIsPressed ? 0 : upIsPressed ? 1 : downIsPressed ? -1 : 0;
        }

        return 0;
    }

    public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
    {
        return ReadValue(ref context);
    }
}

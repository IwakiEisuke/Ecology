public partial class GameManager : Singleton<GameManager>
{
    private readonly GameTimeManager gameTimeManager = new();

    public static float CurrentTime => Instance.gameTimeManager != null ? Instance.gameTimeManager.CurrentTime : -1;
    public static string CurrentTimeString => Instance.gameTimeManager != null ? Instance.gameTimeManager.CurrentTimeString : "GameTimeManager is not found";

    private void Start()
    {
        gameTimeManager.SetTime(0);
    }

    private void Update()
    {
        gameTimeManager.Update();
    }
}

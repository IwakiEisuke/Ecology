public partial class GameManager : Singleton<GameManager>
{
    private GameTimeManager gameTimeManager = new();

    public static float CurrentTime => Instance.gameTimeManager.CurrentTime;
    public static string CurrentTimeString => Instance.gameTimeManager.CurrentTimeString;

    private void Start()
    {
        gameTimeManager.SetTime(0);
    }

    private void Update()
    {
        gameTimeManager.Update();
    }
}

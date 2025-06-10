/// <summary>
/// ゲーム内時間を管理するクラス
/// </summary>
public class GameTimeManager : Singleton<GameTimeManager>
{
    private float _currentTime = 100;
    public static float CurrentTime => Instance._currentTime;
}

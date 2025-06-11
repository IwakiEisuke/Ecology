using System;
using UnityEngine;

public partial class GameManager
{
    /// <summary>
    /// ゲーム内時間を管理するクラス
    /// </summary>
    private class GameTimeManager
    {
        private float _currentTime;
        public float CurrentTime => _currentTime;
        public string CurrentTimeString => TimeSpan.FromSeconds(_currentTime).ToString(@"dd\.hh\:mm\:ss");

        public void SetTime(float time)
        {
            _currentTime = time;
        }

        public void Update()
        {
            _currentTime += Time.deltaTime;
        }
    }
}
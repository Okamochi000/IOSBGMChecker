using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

/// <summary>
/// バックグラウンドミュージックが再生中であるかの確認
/// </summary>
public class BGMPlayingCheker : MonoBehaviour
{
#if !UNITY_EDITOR && UNITY_IOS
    [DllImport("__Internal")] private static extern bool getSecondaryAudioShouldBeSilencedHint_();
#endif

    public bool IsPlaying { get; private set; } = false;

    [SerializeField] private float interval = 0.2f;

    private Text text_ = null;
    private float playTime_ = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        text_ = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text_ == null) { return; }

        playTime_ += Time.deltaTime;
        if (playTime_ >= interval)
        {
#if !UNITY_EDITOR && UNITY_IOS
            IsPlaying = getSecondaryAudioShouldBeSilencedHint_();
#endif
            if (IsPlaying) { text_.text = "BackgroundMusic\nPlaying"; }
            else { text_.text = "BackgroundMusic\nNot Playing"; }
        }
    }
}

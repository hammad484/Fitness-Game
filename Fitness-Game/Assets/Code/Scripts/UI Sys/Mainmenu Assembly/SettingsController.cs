
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    #region Instance

    private static SettingsController _instance;

    public static SettingsController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SettingsController>();
            }

            return _instance;
        }
    }

    #endregion

    public Slider SoundSlider;
    public Slider MusicSlider;
    public Slider SensitivitySlider;
    
    [SerializeField]
    private Slider MasterSliderVol;

    [SerializeField]
    private Slider MusicSliderVol;
    
    private MainMenuController _mainMenuController;

    private void Awake()
    {

        _instance = this;

    }


    private void Start()
    {
        _mainMenuController = MainMenuController.instance;
        
        MusicVolumeChanged(DataController.instance.musicVolume);
        SfxVolumeChanged(DataController.instance.sfxVolume);
        SensitivityVolumeChanged(DataController.instance.Sensitivity);
    }

    private void SfxVolumeChanged(float newVolume)
    {
        if (MasterSliderVol != null)
        {
           
            MasterSliderVol.value = newVolume;
        }

        if (SoundSlider != null)
        {
            SoundSlider.value = newVolume;
        }

    }

    private void MusicVolumeChanged(float newVolume)
    {
        if (MusicSliderVol != null)
        {
            
            MusicSliderVol.value = newVolume;
        }
        
        if (MusicSlider != null)
        {
            MusicSlider.value = newVolume;
        }
        
    }
    
    private void SensitivityVolumeChanged(float newVolume)
    {
        if (SensitivitySlider != null)
        {
            SensitivitySlider.value = newVolume;
        }
        
    }
    
    
    public void MasterVol()
    {
        if (MasterSliderVol != null)
        {
            float VolValue = MasterSliderVol.value /1f;
            DataController.instance.sfxVolume = VolValue;
        }
    }

    public void MusicVol()
    {
        if (MusicSliderVol != null)
        {
            float VolValue = MusicSliderVol.value / 1f;
            DataController.instance.musicVolume = VolValue;
        }
    }
    
    public void Save()
    {
        _mainMenuController.RemoveLastPanelFormStack();
    }
    
    public void Reset()
    {
        DataController.instance.musicVolume = 1f;
        DataController.instance.sfxVolume = 1f;
        DataController.instance.Sensitivity = 1f;
        
        _mainMenuController.RemoveLastPanelFormStack();

    }

    public void IncreaseValue(Slider inputslider)
    {
        if (inputslider.value != inputslider.maxValue)
        {
            inputslider.value = inputslider.value + 0.1f;
        }
    }

    public void DecreaseValue(Slider inputslider)
    {
        if (inputslider.value != inputslider.minValue)
        {
            inputslider.value = inputslider.value - 0.1f;
        }
    }

    public void SliderValueChange(Slider myslider)
    {
        if (myslider == MusicSlider)
        {
            DataController.instance.musicVolume = myslider.value;
        }

        if (myslider == SoundSlider)
        {
            DataController.instance.sfxVolume = myslider.value;
        }

        if (myslider == SensitivitySlider)
        {
            DataController.instance.Sensitivity = myslider.value;
        }

    }



}

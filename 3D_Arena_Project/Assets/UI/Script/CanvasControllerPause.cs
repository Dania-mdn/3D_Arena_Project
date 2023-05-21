using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CanvasControllerPause : MonoBehaviour
{
    [SerializeField] private GameObject _pauzePanel;
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private TextMeshProUGUI _enemyDestroyCount;
    [SerializeField] private Slider _helthSlider;
    [SerializeField] private Image _powerSlider;
    [SerializeField] private Button _powerButton;
    private void OnEnable()
    {
        EventManager.SetMaxPlayerHelth += SetMaxPlayerHelth;
        EventManager.SetPlayerHealth += SetPlayerHelthSlider;
        EventManager.SetPlayerPower += SetPlayerPowerSlider;
        EventManager.EndGame += EndGame;

    }
    private void OnDisable()
    {
        EventManager.SetMaxPlayerHelth -= SetMaxPlayerHelth;
        EventManager.SetPlayerHealth -= SetPlayerHelthSlider;
        EventManager.SetPlayerPower -= SetPlayerPowerSlider;
        EventManager.EndGame -= EndGame;
    }
    private void SetMaxPlayerHelth(int _maxHealth)
    {
        _helthSlider.maxValue = _maxHealth;
    }
    private void SetPlayerHelthSlider(int HelthPlayer)
    {
        _helthSlider.value = HelthPlayer;
    }
    private void SetPlayerPowerSlider(int PowerPlayer)
    {
        _powerSlider.fillAmount = PowerPlayer / 90f;
        if(_powerSlider.fillAmount == 1)
            _powerButton.enabled = true;
        else
            _powerButton.enabled = false;
    }
    public void Pauze(bool isPauzed)
    {
        _pauzePanel.SetActive(isPauzed);
    }
    public void EndGame(int DestroyCount)
    {
        _enemyDestroyCount.text = "Enemies destroyed: " + DestroyCount.ToString();
        _endGamePanel.SetActive(true);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}

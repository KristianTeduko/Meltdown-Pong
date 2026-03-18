using UnityEngine;

public class GameController : MonoBehaviour
{

    public LifeSystem LifeSystem;

    //public GameObject Pause;
    //public GameObject Play;
    public GameObject MainMenu;
    public GameObject FrozenDown;
    public GameObject MeltedDown;

    //public GameObject Lose;


    enum gamestate
    {
        playing,
        pause,
        freezedown,
        meltdown,
        mainmenu
    }

    gamestate currentstate = gamestate.playing;


    public void PlayState()
    {
        StateControl(gamestate.playing);
        LifeSystem.ResetLifes();


    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {

    }
    void Start()
    {
        StateControl(gamestate.mainmenu);
    }

    public void startPlay()
    {
        StateControl(gamestate.playing);
        LifeSystem.ResetLifes();
    }

    public void freezedownGameOver()
    {
        StateControl(gamestate.freezedown);
    }

    public void meltdownGameOver()
    {
        StateControl(gamestate.meltdown);
    }

    public void pauseState()
    {
        StateControl(gamestate.pause);
    }

    void StateControl(gamestate _gamestate)
    {


        currentstate = _gamestate;
        switch (currentstate)
        {


            case gamestate.playing:
                MainMenu.SetActive(false);
                FrozenDown.SetActive(false);
                MeltedDown.SetActive(false);
                Time.timeScale = 1f;

                break;

            case gamestate.pause:
                MainMenu.SetActive(true);
                Time.timeScale = 0f;

                break;


            case gamestate.freezedown:
                FrozenDown.SetActive(true);
                Time.timeScale = 0f;

                break;

            case gamestate.meltdown:
                MeltedDown.SetActive(true);
                Time.timeScale = 0f;

                break;

            case gamestate.mainmenu:
                MainMenu.SetActive(true);
                FrozenDown.SetActive(false);
                MeltedDown.SetActive(false);
                Time.timeScale = 0f;

                break;


        }




    }


}

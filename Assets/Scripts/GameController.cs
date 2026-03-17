using UnityEngine;

public class GameController : MonoBehaviour
{

    //public GameObject Win;
    //public GameObject Pause;
    //public GameObject Lose;
    //public GameObject FrozenDown;
    //public GameObject MeltedDown;


    enum gamestate
    {
        playing,
        pause,
        freezedown,
        meltdown
    }

    gamestate currentstate = gamestate.playing;


    public void PlayState()
    {
        StateControl(gamestate.playing);

    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {

    }
    void Start()
    {
        StateControl(gamestate.playing);
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
                //Pause.SetActive(false);
                Time.timeScale = 1f;
                break;;

            case gamestate.pause:
                //Pause.SetActive(true);
                Time.timeScale = 0f;

                break;


            case gamestate.freezedown:
                //Lose.SetActive(true);
                Time.timeScale = 0f;

                break;

            case gamestate.meltdown:
                //Lose.SetActive(true);
                Time.timeScale = 0f;

                break;


        }




    }


}

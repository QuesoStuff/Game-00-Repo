using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UI_Stats_1 : UI
{
    // Add a variable for the countdown duration.
    [SerializeField] private int countdownDuration_ = CONSTANTS.DEFAULT_START_COUNTDOWN;
    [SerializeField] private float waitTime_ = CONSTANTS.DEFAULT_START_COUNTDOWN_WAIT_TIME;
    private Vector3 initialScale_;


    public void Init_Color()
    {
        List<float> thresholds = new List<float>();
        for (int i = 1; i < countdownDuration_; i++)
        {
            thresholds.Add(i);
        }
        ColorRange colorGradiant = new ColorRange(Color.red, Color.yellow, countdownDuration_);
        List<Color> colors = colorGradiant.GetColors();
        collectionColorRange_ = new CollectionRange<float, Color>(thresholds, colors);
    }

    public void Update_UI_CountDown(Action method = null, int countdown = -1)
    {
        initialScale_ = transform.localScale;
        Init_Color();
        StartCoroutine(StartCountdown(method, countdown));
    }
    public void updateTextColor(int currCountDown = 1)
    {
        textBox_.color = collectionColorRange_.GetResultBasedOnThreshold(currCountDown);

    }
    public float NewScale(int bigNumberMode = -1)
    {
        //float scale = 1;
        if (bigNumberMode == -1)
            // random number between
            if (bigNumberMode == 0) // scale up constant
            {

            }
            else if (bigNumberMode == 1) // scale down constant
            {

            }
            else if (bigNumberMode == 2) // scale randomly up
            {

            }
            else if (bigNumberMode == 3) // scale randomly down
            {

            }
            else if (bigNumberMode == 4) // randomly
            {

            }
            else if (bigNumberMode == 2) // randomly up and down
            {

            }
            else  // constatnly 'NO CHANGE'
            {

            }
        return 0;
        /*
                if (countdown == -1)
                    countdown = countdownDuration_;
                float newScale = countdown;
                while (countdown > 0)
                {
                    float? lastNumber = null;
                    newScale = GENERIC.RandomUpDownValue(ref lastNumber, 1, countdownDuration_);
                    StartCoroutine(ScaleOverTime(this.gameObject, transform.localScale, newScale, waitTime_)); Update_UI_Text(countdown.ToString()); // Display the countdown timer
                    textBox_.color = collectionColorRange_.GetResultBasedOnThreshold(countdown);
                    yield return new WaitForSeconds(waitTime_);
                    transform.localScale = initialScale_;
                    countdown--;
                }
                StartCoroutine(ScaleOverTime(this.gameObject, transform.localScale, newScale, waitTime_)); Update_UI_Text("<b>" + "-GO!-" + "</b>"); // Display the countdown timer
                yield return new WaitForSeconds(waitTime_);
                // When the countdown is over, display the play or pause message
                Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position);
                textBox_.text = "";
                textBox_.color = Color.white;
                //Update_UI();
                method?.Invoke();
                transform.localScale = initialScale_;

        */



    }
    public IEnumerator StartCountdown(Action method = null, int countdown = -1, int bigNumberMode = -1)
    {
        if (countdown == -1)
            countdown = countdownDuration_;
        float newScale = countdown;
        while (countdown > 0)
        {
            Update_UI_Text(countdown.ToString()); // Display the countdown timer
            textBox_.color = collectionColorRange_.GetResultBasedOnThreshold(countdown);
            yield return new WaitForSeconds(waitTime_);
            transform.localScale = initialScale_;
            countdown--;
        }
        StartCoroutine(ScaleOverTime(this.gameObject, transform.localScale, newScale, waitTime_));
        Update_UI_Text(CONSTANTS_STRING.DEFAULT_LEVEL_START);
        yield return new WaitForSeconds(waitTime_);
        // When the countdown is over, display the play or pause message
        textBox_.text = "";
        textBox_.color = Color.white;
        //Update_UI();
        method?.Invoke();
        transform.localScale = initialScale_;

    }

}
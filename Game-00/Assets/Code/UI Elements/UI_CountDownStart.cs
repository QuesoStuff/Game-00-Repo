using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UI_CountDownStart : UI
{
    // Add a variable for the countdown duration.
    [SerializeField] private int countdownDuration_ = 7;
    [SerializeField] private float waitTime_ = 1;
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
        colorRange_ = new CollectionRange<float, Color>(thresholds, colors);
    }
    public override void Init()
    {
        initialScale_ = transform.localScale;
        Init_Color();
        StartCoroutine(StartCountdown());
    }
    public void updateTextColor(int currCountDown = 1)
    {
        textBox_.color = colorRange_.GetResultBasedOnThreshold(currCountDown);

    }
    public IEnumerator StartCountdown(Action method = null)
    {
        int countdown = countdownDuration_;
        float randomScale = countdown;
        while (countdown > 0)
        {
            float? lastNumber = null;
            randomScale = GENERIC.RandomUpDownValue(ref lastNumber, 1, 7);
            StartCoroutine(ScaleOverTime(this.gameObject, transform.localScale, randomScale, waitTime_)); Update_UI_Text(countdown.ToString()); // Display the countdown timer
            textBox_.color = colorRange_.GetResultBasedOnThreshold(countdown);
            yield return new WaitForSeconds(waitTime_);
            transform.localScale = initialScale_;
            countdown--;
            randomScale--;
        }
        // When the countdown is over, display the play or pause message
        Spawning_Main.instance_.spawning_SFX_.Spawn_ExplosionDeath(transform.position);
        textBox_.text = "";
        textBox_.color = Color.white;
        Update_UI();
        method?.Invoke();

    }

}
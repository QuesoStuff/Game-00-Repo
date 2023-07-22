using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionRange<TThreshold, TValue>
{
    private List<TThreshold> thresholds_;
    private List<TValue> values_;

    public CollectionRange(List<TThreshold> thresholds = null, List<TValue> values = null)
    {
        InitializeLists(thresholds, values);
    }



    private void InitializeLists(List<TThreshold> thresholds = null, List<TValue> values = null)
    {
        thresholds ??= new List<TThreshold>();
        values ??= new List<TValue>();
        thresholds_ = thresholds;
        values_ = values;
    }



    public void SetThresholdsInReverseOrder()
    {
        thresholds_.Reverse();
    }

    public void SetValuesInReverseOrder()
    {
        values_.Reverse();
    }

    public void SetThresholdsForCustomSequence(List<TThreshold> newThresholds)
    {
        if (newThresholds.Count == thresholds_.Count)
        {
            thresholds_ = new List<TThreshold>(newThresholds);
        }
        else
        {
            throw new System.ArgumentException("Input list's length is not matching with current thresholds list length.");
        }
    }

    public void SetValuesForCustomSequence(List<TValue> newValues)
    {
        if (newValues.Count == values_.Count)
        {
            values_ = new List<TValue>(newValues);
        }
        else
        {
            throw new System.ArgumentException("Input list's length is not matching with current values list length.");
        }
    }
    public TValue GetResultBasedOnThreshold(TThreshold comparisonValue)
    {
        return GENERIC.PerformOperationOnThreshold<TValue, TThreshold>(thresholds_, values_, comparisonValue, (x, y) => Comparer<TThreshold>.Default.Compare(x, y) <= 0);
    }


    public List<TThreshold> GetThresholds()
    {
        return thresholds_;
    }

    public List<TValue> GetValues()
    {
        return values_;
    }

}

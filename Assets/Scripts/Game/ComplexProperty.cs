using System.Collections;
using System.Collections.Generic;
using System;

public interface IProperty<T>
{
    T GetValue(IGameContext context = null);
    void AddModifier(AbstractProperty<T>.ValueModifier modifier);
}

public class SummProperty : IProperty<int>
{
    AbstractProperty<int> data;
    public SummProperty (int value)
    {
        data = new AbstractProperty<int>(value, summ);
    }

    public void AddModifier(AbstractProperty<int>.ValueModifier modifier)
    {
        data.AddModifier(modifier);
    }

    public int GetValue(IGameContext context = null)
    {
        return data.GetValue(context);
    }

    private int summ(int v1, int v2)
    {
        return v1 + v2;
    }
}

public class MultProperty: IProperty<float>
{
    AbstractProperty<float> data;
    public MultProperty(float value)
    {
        data = new AbstractProperty<float>(value, multiply);
    }

    public void AddModifier(AbstractProperty<float>.ValueModifier modifier)
    {
        data.AddModifier(modifier);
    }

    public float GetValue(IGameContext context = null)
    {
        return data.GetValue(context);
    }

    private float multiply(float v1, float v2)
    {
        return v1 * v2;
    }
}

public class AbstractProperty<T>
{
    public delegate T ValueMethod(T v0, T v1);
    public delegate T ValueModifier(IGameContext context);

    private T baseValue;
    private List<ValueModifier> valueProcess;
    private ValueMethod method;

    public AbstractProperty(T defaultValue, ValueMethod method) 
    {
        this.method = method;
        this.baseValue = defaultValue;
    }

    public T GetValue(IGameContext context = null)
    {
        T value = baseValue;
        if (context != null)
        {
            for (int i = 0, length = valueProcess.Count; i < length; i++)
            {
                value = method(value, valueProcess[i](context));
            }

        }
        return value;
    }

    public void AddModifier(ValueModifier modifier)
    {
        valueProcess.Add(modifier);
    }
}

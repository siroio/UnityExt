using System.Collections.Generic;
using System;
using System.Collections;

/// <summary>
/// This class fires an event when a value is changed.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ReactiveValue<T>
{
    public T value { get; private set; }

    public T defaultValue { get; }

    public event Action<T> changed;

    private readonly EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;

    public ReactiveValue(T value, Action<T> events = default,T defaultValue = default) 
    {
        if(events != default) changed += events;
        this.value = value;
        this.defaultValue = defaultValue;
        changed?.Invoke(value);
    }

    /// <summary>
    /// Change value
    /// </summary>
    /// <param name="value"></param>
    public void Set(T value) {
        if(equalityComparer.Equals(this.value, value)) return;
        lock (this)
        {
            this.value = value;
            changed?.Invoke(value);
        }
    }

    /// <summary>
    /// Set value to default
    /// </summary>
    public void Default()
    {
        lock (this)
        {
            value = defaultValue;
            changed?.Invoke(value);
        }
    }
}
using System;
using System.Collections.Generic;

public class Temperature : IComparable<Temperature>
{
    // Implement the generic CompareTo method with the Temperature 
    // class as the Type parameter. 
    //
    public int CompareTo(Temperature other)
    {
        // If other is not a valid object reference, this instance is greater.
        if (other == null) return 1;

        // The temperature comparison depends on the comparison of 
        // the underlying Double values. 
        return m_value.CompareTo(other.m_value);
    }

    // The underlying temperature value.
    protected double m_value = 0.0;

    public double Celsius
    {
        get
        {
            return m_value - 273.15;
        }
    }

    public double Kelvin
    {
        get
        {
            return m_value;
        }
        set
        {
            if (value < 0.0)
            {
                throw new ArgumentException("Temperature cannot be less than absolute zero.");
            }
            else
            {
                m_value = value;
            }
        }
    }

    public Temperature(double kelvins)
    {
        this.Kelvin = kelvins;
    }
}
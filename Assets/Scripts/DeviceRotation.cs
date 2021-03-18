using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeviceRotation
{
    private static bool gyroInitialized = false;

    public static bool HasGyroscope
    {
        get
        {
            return SystemInfo.supportsGyroscope;
        }
    }

    public static Quaternion Get()
    {
        if (!gyroInitialized)
        {
            InitializeGyro();
        }

        return HasGyroscope
            ? ReadGyroscopeRotation()
            : Quaternion.identity;
    }

    private static void InitializeGyro()
    {
        if (HasGyroscope)
        {
            // enable the gyroscope
            Input.gyro.enabled = true;

            // set the update interval to it's highest value (60 Hz)
            Input.gyro.updateInterval = 0.0167f;    
        }
        gyroInitialized = true;
    }

    private static Quaternion ReadGyroscopeRotation()
    {
        return new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
    }
}

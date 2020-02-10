using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double Lenght { get; set; }

    private double Width { get; set; }

    private double Height { get; set; }

    public Box(double lenght, double width, double height)
    {
        Lenght = lenght;
        Width = width;
        Height = height;
    }

    public double SurfaceArea(double lenght, double width, double height)
    {
        var calculateSurfaceArea
            = (2 * lenght * width)
            + (2 * lenght * height)
            + (2 * width * height);
        return calculateSurfaceArea;
    }

    public double LateralSurfaceArea(double lenght, double width, double height)
    {
        var calculateLateralArea
            = (2 * lenght * height)
            + (2 * width * height);
        return calculateLateralArea;
    }

    public double Volume(double lenght, double width, double height)
    {
        var calculateVolume
            = lenght * width * height;
        return calculateVolume;
    }
}


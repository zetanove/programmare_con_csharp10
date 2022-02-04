// See https://aka.ms/new-console-template for more information

using System;

Console.WriteLine("Records!");

Point3D p1 = new(1,2,3);
Point3D p2 = new();
Console.WriteLine(p1); 
Console.WriteLine(p2);

public record struct Point3D(int X,int Y, int Z);
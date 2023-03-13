using System;
// See https://aka.ms/new-console-template for more information
using DutyHoursCalculatorApp;


Processor.Run();
Console.WriteLine(Processor.GetAllDailyHours.Sum(d => d.Total()));
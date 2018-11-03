# SwapiDC
Console application for calculating required number of stops to resupply that the starship need to take for the given distance.

## Screenshot
![console](https://github.com/stsrki/SwapiDC/blob/master/Docs/console.png)

## How to use
When the aplication starts the you will be prompted to enter the distance. After entering the distance the application will connect to the [swapi.co](https://swapi.co) and download all available starships. The results will be given for all the ships that have a known speed in MGLT. Others will be listed as unsuported.

To close the application just write the "exit" command.

## Requirements 
- .NET Framework 4.7.2
- C# 7.3

## Testing
All the unit tests can be found in the solution.

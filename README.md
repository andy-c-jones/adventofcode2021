# Advent Of Code 2021

Join in at https://adventofcode.com

# Build & Test

Run `./precommit.sh`


## Day One
To calculate depth increases:
```
cd csharp
dotnet sonar/bin/Debug/net6.0/sonar.dll day1 "./sonar/bin/Debug/net6.0/Inputs/day1Input.txt"
```

## Day Two
To move a submarine:
```
cd csharp
dotnet sonar/bin/Debug/net6.0/sonar.dll day2 "./sonar/bin/Debug/net6.0/Inputs/day2Input.txt"
```

## Day Three
```
cd csharp
dotnet sonar/bin/Debug/net6.0/sonar.dll day3 "./sonar/bin/Debug/net6.0/Inputs/day3Input.txt"
```

## Day Four
```
cd csharp
dotnet sonar/bin/Debug/net6.0/sonar.dll day4 "./sonar/bin/Debug/net6.0/Inputs/day4Input.txt"
```

## Day Five
```
cd csharp
dotnet sonar/bin/Debug/net6.0/sonar.dll day5 "./sonar/bin/Debug/net6.0/Inputs/day5Input.txt"
```

## Day Six+
On day 6 I switched to Typescript to calculate lantern fish and used tests to feed in each days input.
```
cd ts
npm install
npm test
```


from helper import getInput  # type: ignore

inputStringList = getInput().split('\n')
print(inputStringList)


def niceStringWalker(string: str) -> bool:
    vowelCount = 0
    doubleLetter = False
    naughtySubStrings = ["ab", "cd", "pq", "xy"]

    previousLetter = ""
    for letter in string:
        if previousLetter == letter:
            doubleLetter = True

        if previousLetter + letter in naughtySubStrings:
            return False

        if letter in "aeiou":
            vowelCount += 1
        previousLetter = letter

    return doubleLetter and (vowelCount >= 3)


def niceStringWalker2(string: str) -> bool:
    pairOfLetters = False
    repeatingElevation = False

    for i in range(2, len(string)):
        if string[i-2:i] in string[:i-2] + "_" + string[i:]:
            pairOfLetters = True
        
        if string[i-2] == string[i]:
            repeatingElevation = True

    return pairOfLetters and repeatingElevation

def DEBUGniceStringWalker2(string: str) -> bool:
    pairOfLetters = False
    repeatingElevation = False

    for i in range(2, len(string)):
        if string[i-2:i] in string[:i-2] + string[i:]:
            pairOfLetters = True
        
        if string[i-2] == string[i]:
            repeatingElevation = True

    return pairOfLetters, repeatingElevation

niceStringCount = 0
for inputString in inputStringList:
    output = DEBUGniceStringWalker2(inputString)
    print(f"{inputString}: {output}")
    niceStringCount += 1 if niceStringWalker2(inputString) else 0

print(niceStringCount)
print(DEBUGniceStringWalker2("gtjscincktlwwkkf"))

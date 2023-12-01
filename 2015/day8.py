from helper import getInput  # type: ignore
import codecs

inputStringList = getInput().split('\n')

def calculateStringLength(string: str) -> int:
    #So you should like never do this
    string = bytes(string, "utf-8").decode("unicode_escape")[1:-1]
    return len(string)



if __name__ == '__main__':
    characters: int = 0
    for string in inputStringList:
        characters += len(string) - calculateStringLength(string)
    
    charactersOfPartTwo: int = 0
    for string in inputStringList:
        print(string.encode("ascii").decode("utf-8"))
        charactersOfPartTwo += len(string.encode("ascii").decode("utf-8")) + 2 - len(string)
    
    print(charactersOfPartTwo)
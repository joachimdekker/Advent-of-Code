from helper import getInput # type: ignore

inputString = getInput().split("\n")

def calculateWrappingPaper(stringList: list):
    area = 0    
    for string in stringList:
        l,w,h = [int(i) for i in string.split("x")]
        areaOfBoxArray = [l*w, w*h, h*l]

        area += 2 * sum(areaOfBoxArray) + min(areaOfBoxArray)
    
    return area

def calculateRibbon(stringList: list):
    length = 0    
    for string in stringList:
        l,w,h = sorted([int(i) for i in string.split("x")])

        length += l*2 + w*2 + l*w*h
    
    return length


print(calculateWrappingPaper(inputString))
print(calculateRibbon(inputString))


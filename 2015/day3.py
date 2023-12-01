from helper import getInput # type: ignore

inputString = getInput()

def countVisitedHouses(inputString: str) -> int:
    currentLocation = [0,0]
    allLocations = ["0-0"]
    for direction in inputString:
        if direction == ">":
            currentLocation[0] += 1
        elif direction == "<":
            currentLocation[0] -= 1
        elif direction == "v":
            currentLocation[1] -= 1
        else:
            currentLocation[1] += 1
        
        allLocations.append("-".join([str(i) for i in currentLocation]))
    
    return len(set(allLocations))

def roboCountVisitedHouses(inputString: str) -> int:
    SantaLocation = [0,0]
    RoboLocation = [0,0]
    allLocations = ["0-0"]
    for i in range(len(inputString)):
        direction = inputString[i]
        currentLocation = SantaLocation if i % 2 == 0 else RoboLocation
        if direction == ">":
            currentLocation[0] += 1
        elif direction == "<":
            currentLocation[0] -= 1
        elif direction == "v":
            currentLocation[1] -= 1
        else:
            currentLocation[1] += 1
        
        allLocations.append("-".join([str(i) for i in currentLocation]))
    
    return len(set(allLocations))

print(countVisitedHouses(inputString))
print(roboCountVisitedHouses(inputString))



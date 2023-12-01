from helper import getInput  # type: ignore
import numpy as np

inputStringList = getInput().split('\n')

gridArr = np.zeros((1000,1000))

def turnLightsByInstruction(grid: np.ndarray, instruction: str):
    instruction = instruction.split()
    
    #decompose instruction
    action = " ".join(instruction[:-3])

    rightCoordinate = [int(i) for i in instruction[-3].split(",")]
    leftCoordinate = [int(i) for i in instruction[-1].split(",")]

    if action == "turn off":
        grid[rightCoordinate[0]:leftCoordinate[0]+1, rightCoordinate[1]:leftCoordinate[1]+1] = 0
    elif action == "turn on":
        grid[rightCoordinate[0]:leftCoordinate[0]+1, rightCoordinate[1]:leftCoordinate[1]+1] = 1
    elif action == "toggle":
        grid[rightCoordinate[0]:leftCoordinate[0]+1, rightCoordinate[1]:leftCoordinate[1]+1] = (grid[rightCoordinate[0]:leftCoordinate[0]+1, rightCoordinate[1]:leftCoordinate[1]+1] + 1)%2

    return grid

def calculateBrightnessOfArea(grid: np.ndarray, instruction: str):
    instruction = instruction.split()
    
    #decompose instruction
    action = " ".join(instruction[:-3])

    rightCoordinate = [int(i) for i in instruction[-3].split(",")]
    leftCoordinate = [int(i) for i in instruction[-1].split(",")]

    greaterThanOne = grid[rightCoordinate[0]:leftCoordinate[0]+1, rightCoordinate[1]:leftCoordinate[1]+1] >= 1

    if action == "turn off":
        grid[rightCoordinate[0]:leftCoordinate[0]+1, rightCoordinate[1]:leftCoordinate[1]+1][greaterThanOne] -= 1
    elif action == "turn on":
        grid[rightCoordinate[0]:leftCoordinate[0]+1, rightCoordinate[1]:leftCoordinate[1]+1] += 1
    elif action == "toggle":
        grid[rightCoordinate[0]:leftCoordinate[0]+1, rightCoordinate[1]:leftCoordinate[1]+1] += 2
    
    return grid

if __name__ == "__main__":
    totalBrightness = 0
    for inputString in inputStringList:
        gridArr = calculateBrightnessOfArea(gridArr, inputString)
    print(np.sum(gridArr))
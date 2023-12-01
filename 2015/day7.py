from typing import Union
import numpy as np
from numpy.core.fromnumeric import var
from helper import getInput  # type: ignore

inputStringList = getInput().split('\n')
Board = dict[str, int]
board: Board = dict()

def getSignalByName(gateName: str) -> int:
    if gateName in board:
        return board[gateName]
    else:
        return calculateGateByInstruction(gateName)

def calculateGateByInstruction(gateName: str) -> int:
    instruction = getInstructionByName(gateName).split()
    if "NOT" in instruction:
        board[gateName] = ~convertSignalNameToInt(instruction[1])
    elif "AND" in instruction:
        board[gateName] = convertSignalNameToInt(instruction[0]) & convertSignalNameToInt(instruction[2])
    elif "OR" in instruction:
        board[gateName] = convertSignalNameToInt(instruction[0]) | convertSignalNameToInt(instruction[2])
    elif "RSHIFT" in instruction:
        board[gateName] = convertSignalNameToInt(instruction[0]) >> convertSignalNameToInt(instruction[2])
    elif "LSHIFT" in instruction:
        board[gateName] = convertSignalNameToInt(instruction[0]) << convertSignalNameToInt(instruction[2])
    else:
        print(instruction)
        board[gateName] = convertSignalNameToInt(instruction[0])
    
    return board[gateName]

def convertSignalNameToInt(string: str) -> int:
    try:
        return np.uint16(string)
    except ValueError:
        return getSignalByName(string)

def getInstructionByName(gateName: str) -> str:
    for string in inputStringList:
        if gateName == string.split()[-1]:
            return string

if __name__ == "__main__":
    print(getSignalByName("a"))
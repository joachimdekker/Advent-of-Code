import sys


def getInput():
    path = sys.argv[0].split('/')[-1][:-3]
    with open(f"2015/input/{path}.txt", "r",) as f:
        return f.read()

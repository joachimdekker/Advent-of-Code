import hashlib

inputString = "bgvyzdsv"

def findMD5Hash(input: str) -> str:
    for i in range(1000000):
        result = hashlib.md5(f"{inputString}{str(i).zfill(6)}".encode()).hexdigest()

        if result[:5] == "00000":
            print(f"{i} gives {result}")
            return i
    
def findMD5HashWithSixZeroes(input: str) -> str:
    for i in range(10000000):
        result = hashlib.md5(f"{inputString}{str(i).zfill(6)}".encode()).hexdigest()

        if result[:6] == "000000" and result[6] != "0":
            print(f"{i} gives {result}")
            return i
    

print(findMD5Hash(inputString))
print(findMD5HashWithSixZeroes(inputString))
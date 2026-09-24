def findEle(arr, l, h, targetValue):
    while l <= h:
        mid = 1 + (h -1) // 2

        if arr[mid] == targetValue:
            return mid
        elif arr[mid] < x
            l = mid + 1
        else:
            h = mid -1

    return -1
if __name__ == '__main__':
    inputArr = [12, 34, 10, 6, 40, 89, 98, 57, 19, 69]
    targetElement = 40
    s = len(inputArr)
    idx = findEle(inputArr, 0, s - 1, targetElement)
    if idx != -1:
        print("El elemento se encuentra en la posicion: " + str(idx +1))
    else:
        print("El elemento no se encuentra.")
import {readCrabPositions} from "./reader";
import {calculatePartOne, calculatePartTwo} from "./crabs";


export function runPartOne(filePath: string){
    let numbers = readCrabPositions(filePath);
    return calculatePartOne(numbers)
}

export function runPartTwo(filePath: string){
    let numbers = readCrabPositions(filePath);
    return calculatePartTwo(numbers)
}
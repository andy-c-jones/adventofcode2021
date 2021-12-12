import {readCrabPositions} from "./reader";
import {calculate} from "./crabs";


export function run(filePath: string){
    let numbers = readCrabPositions(filePath);
    return calculate(numbers)
}
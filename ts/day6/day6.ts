import {readFish} from "./reader";
import {executeDay} from "./day";


export function run(filePath: string, daysToPass: number): number {
    let lanternFish = readFish(filePath);
    for (let i = 0; i < daysToPass; i++) {
        lanternFish = executeDay(lanternFish);
    }

    let count = 0;
    for (let fish of lanternFish) {
        count = count + fish.amountOfFishRepresented;
    }
    return count;
}

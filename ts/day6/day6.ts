import {readFish} from "./reader";
import {executeDay} from "./day";


export function run(filePath: string, daysToPass: number): number {
    let lanternFish = readFish(filePath);
    for (let i = 0; i < daysToPass; i++) {
        lanternFish = executeDay(lanternFish);
        // write(lanternFish.toString())
    }
    return lanternFish.length;
}

//
// export function write(output: string) {
//     console.log(output);
// }
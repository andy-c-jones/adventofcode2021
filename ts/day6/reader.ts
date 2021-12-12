import * as fs from 'fs';
import {LanternFishGroup, spawnRateInDays} from "./fish";

export function readFish(filePath: string): LanternFishGroup[] {
    let fishies = fs.readFileSync(filePath, 'utf8')
        .split(',')
        .map(Number);

    let fishMap = new Map<number, number>()
    for (let fishy of fishies) {
        let fishCount = fishMap.get(fishy);
        if (fishCount != undefined) {
            fishMap.set(fishy, (fishCount+1));
        } else {
            fishMap.set(fishy, 1);
        }
    }

    let fishGroups = new Array<LanternFishGroup>();
    fishMap.forEach((value, key) => fishGroups.push({
        amountOfFishRepresented: value,
        daysUntilNewFish: key
    }));
    return fishGroups;


}

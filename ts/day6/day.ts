import {createNewFishGroup, LanternFishGroup, spawnRateInDays} from "./fish";

function deduplicationGroups(existingFishGroups: LanternFishGroup[]) {
    let existingFishies = [];
    for (const existingFish of existingFishGroups) {
        let fishToAppendTo = existingFishies.findIndex(e => e.daysUntilNewFish === existingFish.daysUntilNewFish);
        if (fishToAppendTo != -1) {
            existingFishies[fishToAppendTo].amountOfFishRepresented =
                existingFishies[fishToAppendTo].amountOfFishRepresented + existingFish.amountOfFishRepresented;
        } else {
            existingFishies.push(existingFish);
        }
    }
    return existingFishies;
}

function ageFish(existingFishies: any[]) {
    return existingFishies.map(f => ({
        amountOfFishRepresented: f.amountOfFishRepresented,
        daysUntilNewFish: f.daysUntilNewFish != 0 ? f.daysUntilNewFish - 1 : spawnRateInDays
    }));
}

export function executeDay(existingFishGroups: LanternFishGroup[]): LanternFishGroup[] {
    let existingFishies = deduplicationGroups(existingFishGroups);
    let fish = ageFish(existingFishies);

    let lanternFishGroup = existingFishies.find(f => f.daysUntilNewFish === 0);
    if (!!lanternFishGroup)
        fish.push(createNewFishGroup(lanternFishGroup.amountOfFishRepresented));
    return fish;
}

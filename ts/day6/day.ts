import {createNewFish, LanternFish, spawnRateInDays} from "./fish";

export function executeDay(existingFish: LanternFish[]): LanternFish[] {
    let numberOfNewFishToday = existingFish.filter( f=> f.daysUntilNewFish === 0).length;
    let oldFish = existingFish.map(f => ({daysUntilNewFish: f.daysUntilNewFish != 0 ? f.daysUntilNewFish - 1 : spawnRateInDays}));
    return oldFish.concat([...Array(numberOfNewFishToday)].map(createNewFish));
}

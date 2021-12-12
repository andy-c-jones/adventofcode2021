export type LanternFish = {
    daysUntilNewFish: number
};

export const spawnRateInDays = 6;
const numberOfDaysAsJuvenile = 2;

export function createNewFish(): LanternFish {
    return {daysUntilNewFish: spawnRateInDays + numberOfDaysAsJuvenile}
}

export type LanternFishGroup = {
    amountOfFishRepresented: number,
    daysUntilNewFish: number
};

export const spawnRateInDays = 6;
const numberOfDaysAsJuvenile = 2;

export function createNewFishGroup(amountOfNewFish: number): LanternFishGroup {
    return {
        amountOfFishRepresented: amountOfNewFish,
        daysUntilNewFish: spawnRateInDays + numberOfDaysAsJuvenile
    }
}

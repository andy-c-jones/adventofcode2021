import * as fs from 'fs';

const spawnRateInDays = 6;
const numberOfDaysAsJuvenile = 2;

type LanternFish = {
    daysUntilNewFish: number
};


function createNewFish(): LanternFish {
    return {daysUntilNewFish: spawnRateInDays + numberOfDaysAsJuvenile}
}

export function readFish(filePath: string): LanternFish[] {
    return fs.readFileSync(filePath, 'utf8')
        .split(',')
        .map(n => ({daysUntilNewFish: Number(n)}));
}

export function executeDay(existingFish: LanternFish[]): LanternFish[] {
    return existingFish.map(f => ({daysUntilNewFish: f.daysUntilNewFish - 1}));
}

export function Run(filePath: string): number {

    return 0;
}